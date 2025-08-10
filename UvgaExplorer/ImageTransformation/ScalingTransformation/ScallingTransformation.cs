// <copyright file="ScallingTransformation.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ImageTransformation.ScalingTransformation;

/// <summary>
/// Defines a <see cref="IImageTransformer"/> that scales an image.
/// </summary>
internal class ScallingTransformation
    : IImageTransformer
{
    /// <inheritdoc/>
    public string Name { get; } = "Scale image";

    /// <inheritdoc/>
    public string Description { get; } = "Scales an image up or down.";

    /// <inheritdoc/>
    public Control? GetConfigurationControl(Bitmap image)
    {
        var res = new ScalingTransformationConfig();
        res.Initialize(image);
        return res;
    }

    /// <inheritdoc/>
    public Bitmap? TransformImage(Bitmap image, Control? configurationControl)
    {
        if (configurationControl is not ScalingTransformationConfig config)
        {
            return null;
        }

        var w = (int)(image.Size.Width * config.SelectedScale);
        var h = (int)(image.Size.Height * config.SelectedScale);
        var res = new Bitmap(w, h);
        res.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        using var g = Graphics.FromImage(res);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.DrawImage(image, new Rectangle(0, 0, w, h));
        return res;
    }
}
