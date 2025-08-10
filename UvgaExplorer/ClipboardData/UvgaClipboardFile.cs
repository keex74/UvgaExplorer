// <copyright file="UvgaClipboardFile.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ClipboardData;

using LibUvgaFile;
using UvgaExplorer;

/// <summary>
/// Defines an entry in the Uvga clipboard data.
/// </summary>
[Serializable]
public class UvgaClipboardFile
{
    /// <summary>
    /// Gets or sets the image name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the image data.
    /// </summary>
    public byte[] Data { get; set; } = [];

    /// <summary>
    /// Create a <see cref="UvgaClipboardFile"/> from  <see cref="UvgaImageFile"/>.
    /// </summary>
    /// <param name="sourceImage">The source image.</param>
    /// <returns>The clipboard data.</returns>
    internal static UvgaClipboardFile FromImage(UvgaImageFile sourceImage)
    {
        return new UvgaClipboardFile() { Name = sourceImage.Name, Data = [.. sourceImage.Source.PngImageData] };
    }

    /// <summary>
    /// Convert the items to a <see cref="UvgaImageFile"/>.
    /// </summary>
    /// <returns>The new image.</returns>
    internal UvgaImageContent? ToImage()
    {
        if (string.IsNullOrEmpty(this.Name) || this.Data == null || this.Data.Length == 0)
        {
            return null;
        }

        var src = new UvgaImageContent(this.Name, this.Data);
        return src;
    }
}
