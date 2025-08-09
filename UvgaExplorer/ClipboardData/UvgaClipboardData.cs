// <copyright file="UvgaClipboardData.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ClipboardData;

using LibUvgaFile;

/// <summary>
/// Defines data for uvga clipboard operations.
/// </summary>
[Serializable]
internal class UvgaClipboardData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaClipboardData"/> class.
    /// </summary>
    public UvgaClipboardData()
    {
    }

    /// <summary>
    /// Gets or sets the items in the object.
    /// </summary>
    public List<UvgaClipboardFile> Images { get; set; } = [];

    /// <summary>
    /// Create clipboard data from images.
    /// </summary>
    /// <param name="images">The images.</param>
    /// <returns>The clipboard data.</returns>
    internal static UvgaClipboardData FromImages(IEnumerable<UvgaImageFile> images)
    {
        var res = new UvgaClipboardData();
        foreach (var image in images)
        {
            res.Images.Add(UvgaClipboardFile.FromImage(image));
        }

        return res;
    }

    /// <summary>
    /// Convert the data in this object to <see cref="UvgaImageContent"/> objects.
    /// </summary>
    /// <returns>The iamges.</returns>
    internal IReadOnlyList<UvgaImageContent> ToContent()
    {
        if (this.Images == null)
        {
            return [];
        }

        var res = new List<UvgaImageContent>();
        foreach (var i in this.Images)
        {
            var item = i.ToImage();
            if (item != null)
            {
                res.Add(item);
            }
        }

        return res;
    }
}
