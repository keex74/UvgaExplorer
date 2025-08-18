// <copyright file="AOPrefsFolderHasher.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

/// <summary>
/// Contains a function to find the AO prefs folder hash value.
/// </summary>
public static class AOPrefsFolderHasher
{
    /// <summary>
    /// Calculate the AO preference folder hash from the given AO game directory.
    /// </summary>
    /// <param name="aoGameFolder">The AO game directory, where e.g. AnarchyOnline.exe lives.</param>
    /// <returns>The hash string used in %localappdata\Funcom\Anarchy Online\-hash-\...</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="aoGameFolder"/> is null or empty.</exception>
    public static string GetPrefsHash(string aoGameFolder)
    {
        if (string.IsNullOrEmpty(aoGameFolder))
        {
            throw new ArgumentNullException(nameof(aoGameFolder));
        }

        // Find parent folder and convert path to use forward slashes
        aoGameFolder = Path.GetFullPath(aoGameFolder);
        var parentFolder = Directory.GetParent(aoGameFolder);
        if (parentFolder == null)
        {
            return string.Empty;
        }

        var parent = parentFolder.FullName;
        if (parent.EndsWith(Path.DirectorySeparatorChar))
        {
            // Cut of the directory separator at the end.
            // It shouldn't be there in the first place, but I don't think that's guaranteed.
            parent = parent[..^1];
        }

        // Boost library TPATH uses slashes for directory separators
        parent = parent.Replace(Path.DirectorySeparatorChar, '/');

        // Do the actual hash calculation, from Boost 1.53 library boost\functional\hash.hpp
        var bytes = System.Text.Encoding.ASCII.GetBytes(parent);
        const uint Constant = 0x9e3779b9;
        uint seed = 0;
        for (int i = 0; i < bytes.Length; i++)
        {
            var b = (uint)bytes[i];
            seed ^= b + Constant + (seed << 6) + (seed >> 2);
        }

        // Convert hash to string
        var hashBytes = BitConverter.GetBytes(seed);
        Array.Reverse(hashBytes);
        var hashStr = BitConverter.ToString(hashBytes).ToLower().Replace("-", string.Empty);
        return hashStr;
    }

    /// <summary>
    /// Calculate the AO preference folder hash from the given AO game directory.
    /// </summary>
    /// <param name="aoGameFolder">The AO game directory, where e.g. AnarchyOnline.exe lives.</param>
    /// <returns>The hash string used in %localappdata\Funcom\Anarchy Online\-hash-\...</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="aoGameFolder"/> is null or empty.</exception>
    public static DirectoryInfo GetPrefsFolder(string aoGameFolder)
    {
        if (string.IsNullOrEmpty(aoGameFolder))
        {
            throw new ArgumentNullException(nameof(aoGameFolder));
        }

        // Find parent folder and convert path to use forward slashes
        aoGameFolder = Path.GetFullPath(aoGameFolder);
        var aoGameFolderName = Path.GetFileName(aoGameFolder);
        var localAppdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var hash = GetPrefsHash(aoGameFolder);
        var prefsPath = Path.Combine(localAppdata, "Funcom", "Anarchy Online", hash, aoGameFolderName);
        return new DirectoryInfo(prefsPath);
    }
}
