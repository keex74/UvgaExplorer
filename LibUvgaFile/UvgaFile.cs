// <copyright file="UvgaFile.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace LibUvgaFile;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Defines a UVGA file.
/// </summary>
public class UvgaFile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaFile"/> class.
    /// </summary>
    public UvgaFile()
    {
        this.Images = [];
        this.SourceUvgiPath = string.Empty;
        this.SourceUvgaPath = string.Empty;
    }

    /// <summary>
    /// Gets or sets the path to the uvgi file that the object was loaded from.
    /// </summary>
    public string SourceUvgiPath { get; set; }

    /// <summary>
    /// Gets or sets the path to the uvgi file that the object was loaded from.
    /// </summary>
    public string SourceUvgaPath { get; set; }

    /// <summary>
    /// Gets the list of images in the file.
    /// </summary>
    public List<UvgaImageContent> Images { get; }

    /// <summary>
    /// Load UVGA data from the given file.
    /// </summary>
    /// <param name="filename">The file name. Can be either .uvgi or .uvga. The base file name with corresponding extensions are loaded.</param>
    /// <returns>The loaded file.</returns>
    /// <exception cref="ArgumentException">If no uvga+uvgi with the given base name can be found.</exception>
    /// <exception cref="FormatException">If any of the file's formats are wrong.</exception>
    public static UvgaFile Load(string filename)
    {
        var x = System.IO.Path.GetFullPath(filename);
        var dir = Path.GetDirectoryName(x);
        var filenameBase = Path.GetFileNameWithoutExtension(x);
        var uvgi = Path.Combine(dir, filenameBase + ".uvgi");
        var uvga = Path.Combine(dir, filenameBase + ".uvga");
        if (!File.Exists(uvgi) || !File.Exists(uvga))
        {
            throw new ArgumentException("The path does not contain the neccessary .uvgi and .uvga files.");
        }

        using var sr = new StreamReader(uvgi);
        var res = new UvgaFile()
        {
            SourceUvgaPath = uvga,
            SourceUvgiPath = uvgi,
        };

        using var fs = File.OpenRead(uvga);

        if (!int.TryParse(sr.ReadLine(), out int nImages))
        {
            throw new FormatException("Invalid number of images");
        }

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            if (line == null)
            {
                break;
            }

            var parts = line.Split([' '], StringSplitOptions.None);
            if (parts.Length != 3 || !int.TryParse(parts[1], out int offset) || !int.TryParse(parts[2], out int length))
            {
                throw new FormatException("Invalid line entry in UVGI");
            }

            if (offset + length > fs.Length)
            {
                throw new FormatException("Invalid offset and length of image entry");
            }

            fs.Seek(offset, SeekOrigin.Begin);
            var buffer = new byte[length];
            var didRead = fs.Read(buffer, 0, length);
            if (didRead < length)
            {
                throw new FormatException("Failed to read the correct amount of data from the UVGA");
            }

            res.Images.Add(new UvgaImageContent(parts[0], buffer));
        }

        if (res.Images.Count != nImages)
        {
            throw new FormatException($"Invalid image data list: Expected {nImages}, actually found {res.Images.Count}");
        }

        return res;
    }

    /// <summary>
    /// Save the file to under the given name.
    /// </summary>
    /// <param name="targetFilename">The target filename. Creates .uvgi and .uvga files with the given base filename.</param>
    /// <param name="makeBackup">If true, a backup of an already existing file is created.</param>
    /// <returns>The path to the new Uvga and Uvgi files.</returns>
    public (string UvgaPath, string UvgiPath) Save(string targetFilename, bool makeBackup)
    {
        var x = System.IO.Path.GetFullPath(targetFilename);
        var targetDir = Path.GetDirectoryName(x);
        var filenameBase = Path.GetFileNameWithoutExtension(x);
        var sourceUvgi = Path.Combine(targetDir, filenameBase + ".uvgi");
        var sourceUvga = Path.Combine(targetDir, filenameBase + ".uvga");

        // Check access
        TestPathAccess(targetDir);

        if (makeBackup)
        {
            var d = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
            var backupNameA = $"Graphics-{d}.uvga";
            var backupNameI = $"Graphics-{d}.uvgi";
            if (File.Exists(sourceUvgi))
            {
                File.Copy(sourceUvgi, Path.Combine(targetDir, backupNameI));
            }

            if (File.Exists(sourceUvga))
            {
                File.Copy(sourceUvga, Path.Combine(targetDir, backupNameA));
            }
        }

        var tempA = Path.GetTempFileName();
        var tempI = Path.GetTempFileName();
        var tempBackupA = Path.GetTempFileName();
        var tempBackupI = Path.GetTempFileName();

        try
        {
            using (var sw = new StreamWriter(tempI))
            {
                using var fs = File.Create(tempA);
                sw.WriteLine(this.Images.Count.ToString());
                foreach (var i in this.Images)
                {
                    var data = i.ImageData.ToArray();
                    var name = i.Name;
                    sw.WriteLine($"{name} {fs.Position} {data.Length}");
                    fs.Write(data, 0, data.Length);
                }
            }

            // Copy original files to temp files
            var didCopyA = !File.Exists(sourceUvga);
            var didCopyI = !File.Exists(sourceUvgi);
            if (!didCopyA)
            {
                File.Copy(sourceUvga, tempBackupA, true);
                didCopyA = true;
            }

            if (!didCopyI)
            {
                File.Copy(sourceUvgi, tempBackupI, true);
                didCopyA = true;
            }

            // So far, the original folder is undisturbed
            try
            {
                File.Delete(sourceUvga);
                File.Copy(tempA, sourceUvga);
                File.Delete(sourceUvgi);
                File.Copy(tempI, sourceUvgi);
            }
            catch (Exception)
            {
                // Yikes, try to clean up again
                try
                {
                    File.Delete(sourceUvga);
                    File.Copy(tempBackupA, sourceUvga, true);
                    File.Delete(sourceUvgi);
                    File.Copy(tempBackupI, sourceUvgi, true);
                }
                catch (Exception)
                {
                }

                throw;
            }
        }
        finally
        {
            try
            {
                File.Delete(tempI);
                File.Delete(tempA);
                File.Delete(tempBackupA);
                File.Delete(tempBackupI);
            }
            catch (Exception)
            {
            }
        }

        return (sourceUvga, sourceUvgi);
    }

    private static void TestPathAccess(string path)
    {
        var testFile = Path.Combine(path, Guid.NewGuid().ToString() + ".txt");
        try
        {
            using var fs = File.Create(testFile);
            fs.Write([0, 1, 2, 3, 4, 5], 0, 6);
            fs.Flush();
            fs.Close();

            using var fsR = File.OpenRead(testFile);
            var testBuffer = new byte[6];
            var didRead = fsR.Read(testBuffer, 0, testBuffer.Length);
            fsR.Close();
            if (didRead < testBuffer.Length || !Enumerable.SequenceEqual<byte>(testBuffer, [0, 1, 2, 3, 4, 5]))
            {
                throw new UnauthorizedAccessException("Failed to read in the given path");
            }
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new UnauthorizedAccessException($"Failed to read or write in the given path: {ex.Message}", ex);
        }
        finally
        {
            try
            {
                File.Delete(testFile);
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Failed to delete file in the given path");
            }
        }
    }
}
