// <copyright file="UvgaOperations.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.Drawing.Imaging;
using System.Text;
using LibUvgaFile;

/// <summary>
/// Defines functions to change Uvga files.
/// </summary>
internal static class UvgaOperations
{
    /// <summary>
    /// Open a file.
    /// </summary>
    /// <param name="parent">The parent window.</param>
    /// <returns>The opened file, or null if cancelled/failed.</returns>
    public static UvgaCollection? OpenFile(IWin32Window parent)
    {
        using var dlg = new OpenFileDialog();
        dlg.Filter = "UVGA/I Files|*.uvgi;*.uvga";
        if (dlg.ShowDialog(parent) == DialogResult.OK)
        {
            try
            {
                var uvga = UvgaFile.Load(dlg.FileName);
                var collection = new UvgaCollection(uvga);
                return collection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(parent, $"Failed to open the selected file.{Environment.NewLine}{Environment.NewLine}Error:{Environment.NewLine}{ex}", "Loading failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Save the given file under its current name.
    /// </summary>
    /// <param name="parent">The parent window.</param>
    /// <param name="uvgaFile">The file to save.</param>
    public static void SaveFile(IWin32Window parent, UvgaCollection uvgaFile)
    {
        if (string.IsNullOrEmpty(uvgaFile.SourcePath))
        {
            SaveFileAs(parent, uvgaFile);
            return;
        }

        SaveFileUnder(parent, uvgaFile, uvgaFile.SourcePath);
    }

    /// <summary>
    /// Save the given file under a new name.
    /// </summary>
    /// <param name="parent">The parent window.</param>
    /// <param name="uvgaFile">The uvga file.</param>
    public static void SaveFileAs(IWin32Window parent, UvgaCollection uvgaFile)
    {
        using var sfd = new SaveFileDialog();
        if (!string.IsNullOrEmpty(uvgaFile.SourcePath))
        {
            sfd.InitialDirectory = Path.GetDirectoryName(uvgaFile.SourcePath);
            sfd.FileName = Path.GetFileName(uvgaFile.SourcePath);
        }

        if (sfd.ShowDialog(parent) == DialogResult.Cancel)
        {
            return;
        }

        SaveFileUnder(parent, uvgaFile, sfd.FileName);
    }

    /// <summary>
    /// Import images to the given uvga file.
    /// </summary>
    /// <param name="parent">The parent window.</param>
    /// <param name="uvgaFile">The uvga files.</param>
    /// <param name="imageFiles">The image file names to import.</param>
    public static void ImportImages(IWin32Window parent, UvgaCollection uvgaFile, IEnumerable<string> imageFiles)
    {
        var allok = true;
        foreach (var file in imageFiles)
        {
            try
            {
                var extension = Path.GetExtension(file);
                var data = File.ReadAllBytes(file);

                // Make sure that the image data is a 24bpp PNG.
                data = FixImageData(data);
                var fn = Path.GetFileNameWithoutExtension(file);
                var rawimgfile = new UvgaImageContent(fn, data);
                var imgFile = new UvgaImageFile(rawimgfile);
                ReplaceImage(uvgaFile, imgFile);
            }
            catch (Exception)
            {
                allok = false;
                continue;
            }
        }

        if (!allok)
        {
            MessageBox.Show(parent, "Failed to import some of the images for whatever reason. Please check that only image files were selected.", "Could not import all images", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    /// <summary>
    /// Export the given images.
    /// </summary>
    /// <param name="parent">The parent window.</param>
    /// <param name="selectedImages">The images to export.</param>
    public static void ExportSelectedImages(IWin32Window parent, IReadOnlyCollection<UvgaImageFile> selectedImages)
    {
        if (selectedImages.Count == 0)
        {
            return;
        }

        using var fbd = new FolderBrowserDialog();
        fbd.ShowNewFolderButton = true;
        if (fbd.ShowDialog(parent) != DialogResult.OK)
        {
            return;
        }

        var hasExisting = false;
        foreach (var item in selectedImages)
        {
            var sourceName = item.Name;
            if (string.IsNullOrEmpty(sourceName))
            {
                continue;
            }

            var fn = Path.Combine(fbd.SelectedPath, sourceName + ".png");
            if (File.Exists(fn))
            {
                hasExisting = true;
                break;
            }
        }

        bool overwrite = true;
        if (hasExisting)
        {
            var sb = new StringBuilder();
            sb.AppendLine("The selected folder contains one or more images already. Do you want to overwrite them?");
            sb.AppendLine("[Yes] Overwrite the files");
            sb.AppendLine("[No] Don't overwrite existing files");
            sb.AppendLine("[Cancel] Cancel the export entirely");

            var dlg = MessageBox.Show(parent, sb.ToString(), "Files already exist", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlg == DialogResult.Cancel)
            {
                return;
            }

            overwrite = dlg == DialogResult.Yes;
        }

        try
        {
            foreach (var item in selectedImages)
            {
                var sourceName = item.Name;
                var fn = Path.Combine(fbd.SelectedPath, sourceName + ".png");
                if (File.Exists(fn) && !overwrite)
                {
                    continue;
                }

                File.WriteAllBytes(fn, [.. item.Source.ImageData]);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(parent, $"Failed to export some of the images.{Environment.NewLine}{Environment.NewLine}Error:{Environment.NewLine}{ex}", "Could not export all images", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    /// <summary>
    /// Delete the selected images from the uvga file.
    /// </summary>
    /// <param name="parent">The parent window.</param>
    /// <param name="uvgaFile">The uvga file.</param>
    /// <param name="selectedImages">The selected images.</param>
    /// <param name="showConfirmation">Whether to show a confirmation warning.</param>
    public static void DeleteSelected(IWin32Window parent, UvgaCollection uvgaFile, IReadOnlyCollection<UvgaImageFile> selectedImages, bool showConfirmation = true)
    {
        if (selectedImages.Count == 0)
        {
            return;
        }

        if (showConfirmation)
        {
            var dlg = MessageBox.Show(parent, "Do you want to delete the selected images?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Cancel)
            {
                return;
            }
        }

        foreach (var item in selectedImages)
        {
            uvgaFile.Remove(item);
        }
    }

    /// <summary>
    /// Replace an image in the uvga file with a new one, based on name.
    /// </summary>
    /// <param name="uvgaFile">The uvga file.</param>
    /// <param name="newImage">The new image.</param>
    public static void ReplaceImage(UvgaCollection uvgaFile, UvgaImageFile newImage)
    {
        var fn = newImage.Name;
        var existingImg = uvgaFile.FirstOrDefault(f => f.Name == fn);
        if (existingImg != null)
        {
            var idx = uvgaFile.IndexOf(existingImg);
            uvgaFile[idx] = newImage;
            existingImg.Dispose();
        }
        else
        {
            uvgaFile.Add(newImage);
        }
    }

    /// <summary>
    /// Checks the given image data and converts it to the correct format if needed.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>The fixed data.</returns>
    public static byte[] FixImageData(byte[] data)
    {
        if (!CheckPngPixelFormat(data))
        {
            // Recode the file to png
            using var ms = new MemoryStream(data);
            using var img = Image.FromStream(ms);
            if (img.PixelFormat != PixelFormat.Format24bppRgb)
            {
                // Also change pixel format
                using var bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
                bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                using var g = Graphics.FromImage(bmp);
                g.DrawImageUnscaled(img, new Point(0, 0));
                bmp.SetResolution(96, 96);
                using var msout = new MemoryStream();
                bmp.Save(msout, ImageFormat.Png);
                return msout.ToArray();
            }
            else
            {
                using var msout = new MemoryStream();
                img.Save(msout, ImageFormat.Png);
                return msout.ToArray();
            }
        }
        else
        {
            return data;
        }
    }

    private static void SaveFileUnder(IWin32Window parent, UvgaCollection file, string filename)
    {
        if (string.IsNullOrEmpty(filename))
        {
            return;
        }

        try
        {
            var target = new UvgaFile();
            target.Images.AddRange(file.Select(f => f.Source));
            var (uvgaPath, uvgiPath) = target.Save(filename, Program.UESettings.MakeSaveBackups);
            file.SourcePath = uvgaPath;
            return;
        }
        catch (Exception ex)
        {
            MessageBox.Show(parent, $"Failed to save the file.{Environment.NewLine}{Environment.NewLine}Error:{Environment.NewLine}{ex}", "Saving failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private static bool CheckPngPixelFormat(byte[] data)
    {
        var pngHeader = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 };
        if (!pngHeader.SequenceEqual(data.Take(pngHeader.Length)))
        {
            return false;
        }

        using var ms = new MemoryStream(data);
        using var br = new BinaryReader(ms);
        var buffer = new byte[1024];

        // Skip signature
        ms.Read(buffer, 0, pngHeader.Length);
        var length = BE(br.ReadUInt32());
        if (ms.Position + length + 8 > ms.Length)
        {
            // Invalid length
            return false;
        }

        var type = BE(br.ReadUInt32());
        if (type != (('I' << 24) | ('H' << 16) | ('D' << 8) | 'R'))
        {
            // Invalid chunk type.
            return false;
        }

        var chunkData = new byte[length];
        ms.Read(chunkData, 0, chunkData.Length);
        var crc = BE(br.ReadUInt32());

        using var msChunk = new MemoryStream(chunkData);
        using var brChunk = new BinaryReader(msChunk);
        var width = BE(brChunk.ReadInt32());
        var height = BE(brChunk.ReadInt32());
        var bitdepth = brChunk.ReadByte();
        var colorType = brChunk.ReadByte();
        var compression = brChunk.ReadByte();
        var filter = brChunk.ReadByte();
        var interlace = brChunk.ReadByte();
        return colorType == 2 && bitdepth == 8;
    }

    private static uint BE(uint v)
    {
        var b3 = (v >> 24) & 0xFF;
        var b2 = (v >> 16) & 0xFF;
        var b1 = (v >> 8) & 0xFF;
        var b0 = (v >> 0) & 0xFF;
        return (b0 << 24) | (b1 << 16) | (b2 << 8) | b3;
    }

    private static int BE(int v)
    {
        var bytes = BitConverter.GetBytes(v);
        var rev = bytes.Reverse().ToArray();
        return BitConverter.ToInt32(rev, 0);
    }
}
