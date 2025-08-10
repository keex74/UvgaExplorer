// <copyright file="ScalingTransformationConfig.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ImageTransformation.ScalingTransformation;

/// <summary>
/// Defines a configuration control for the <see cref="ImageScalingTransformation"/>.
/// </summary>
public partial class ScalingTransformationConfig
    : UserControl
{
    private readonly Size originalSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScalingTransformationConfig"/> class.
    /// </summary>
    public ScalingTransformationConfig()
    {
        this.InitializeComponent();
        this.originalSize = new Size(150, 100);
        this.NumScale.ValueChanged += this.NumScale_ValueChanged;
        this.UpdateUI();
    }

    /// <summary>
    /// Gets the selected scale in [%].
    /// </summary>
    public double SelectedScale { get => (double)this.NumScale.Value; }

    private void NumScale_ValueChanged(object? sender, EventArgs e)
    {
        this.UpdateUI();
    }

    private void UpdateUI()
    {
        var scale = this.SelectedScale / 100;
        var w = (int)(this.originalSize.Width * scale);
        var h = (int)(this.originalSize.Height * scale);
        this.LblResultSize.Text = $"{w} x {h}";
    }
}
