// <copyright file="ScalingTransformationConfig.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ImageTransformation.ScalingTransformation;

/// <summary>
/// Defines a configuration control for the
/// </summary>
public partial class ScalingTransformationConfig
    : UserControl
{
    private Size originalSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScalingTransformationConfig"/> class.
    /// </summary>
    public ScalingTransformationConfig()
    {
        this.InitializeComponent();
        this.NumScale.ValueChanged += this.NumScale_ValueChanged;
    }

    /// <summary>
    /// Gets the selected scale in [%].
    /// </summary>
    public double SelectedScale { get => (double)this.NumScale.Value; }

    /// <summary>
    /// Initialize the control.
    /// </summary>
    /// <param name="image">The image to transform.</param>
    public void Initialize(Bitmap image)
    {
        this.originalSize = image.Size;
        this.UpdateUI();
    }

    private void NumScale_ValueChanged(object? sender, EventArgs e)
    {
        this.UpdateUI();
    }

    private void UpdateUI()
    {
        var w = (int)(this.originalSize.Width * this.SelectedScale);
        var h = (int)(this.originalSize.Height * this.SelectedScale);
        this.LblResultSize.Text = $"{w} x {h}";
    }
}
