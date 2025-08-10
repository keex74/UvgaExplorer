// <copyright file="UvgaImageFile.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.Drawing.Imaging;
using LibUvgaFile;

/// <summary>
/// Defines a single image in the UVGA file.
/// </summary>
internal class UvgaImageFile
    : IDisposable
{
    private readonly UvgaImageContent source;
    private bool disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaImageFile"/> class.
    /// </summary>
    /// <param name="source">The source raw image object.</param>
    public UvgaImageFile(UvgaImageContent source)
    {
        this.source = source;
        var images = CreateImages(this.source);
        this.Image = images.Image;
        this.Thumbnail = images.Thumbnail;
    }

    /// <summary>
    /// Gets the name of the source image.
    /// </summary>
    public string Name => this.source.Name;

    /// <summary>
    /// Gets the full image.
    /// </summary>
    public Image Image { get; private set; }

    /// <summary>
    /// Gets the thumbnail image.
    /// </summary>
    public Image Thumbnail { get; private set; }

    /// <summary>
    /// Gets the source raw image data.
    /// </summary>
    public UvgaImageContent Source => this.source;

    /// <inheritdoc/>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose the object.
    /// </summary>
    /// <param name="disposing">If disposing managed content.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                this.Image.Dispose();
                this.Thumbnail.Dispose();
            }

            this.disposedValue = true;
        }
    }

    private static (Image Image, Image Thumbnail) CreateImages(UvgaImageContent source)
    {
        using var ms = new MemoryStream([.. source.PngImageData]);
        var original = Image.FromStream(ms);

        var thumb = new Bitmap(32, 32);
        using var g = Graphics.FromImage(thumb);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        // Remap the full green background to transparent in the thumbnail.
        var map = new ColorMap
        {
            OldColor = Color.FromArgb(0, 255, 0),
            NewColor = Color.FromArgb(0, 255, 255, 255),
        };
        using var attributes = new ImageAttributes();
        attributes.SetRemapTable([map]);
        g.DrawImage(original, new Rectangle(0, 0, thumb.Width, thumb.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
        return (original, thumb);
    }
}
