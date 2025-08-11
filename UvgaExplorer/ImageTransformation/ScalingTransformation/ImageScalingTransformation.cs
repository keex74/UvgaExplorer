// <copyright file="ImageScalingTransformation.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ImageTransformation.ScalingTransformation;

/// <summary>
/// Defines a <see cref="IImageTransformer"/> that scales an image.
/// </summary>
internal class ImageScalingTransformation
    : IImageTransformer
{
    /// <inheritdoc/>
    public string Name { get; } = "Scale image";

    /// <inheritdoc/>
    public string Description { get; } = "Scales an image up or down.";

    /// <inheritdoc/>
    public Control? GetConfigurationControl()
    {
        var res = new ScalingTransformationConfig();
        return res;
    }

    /// <inheritdoc/>
    public Bitmap? TransformImage(Image image, Control? configurationControl)
    {
        if (configurationControl is not ScalingTransformationConfig config)
        {
            return null;
        }

        var scale = config.SelectedScale / 100;
        var w = (int)(image.Size.Width * scale);
        var h = (int)(image.Size.Height * scale);
        var res = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        res.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        using var g = Graphics.FromImage(res);
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.DrawImage(image, new Rectangle(0, 0, w, h));
        return res;
    }
}
