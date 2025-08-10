// <copyright file="UvgaImageContent.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace LibUvgaFile;

using System.Collections.Generic;

/// <summary>
/// Defines a single image in an Uvga file.
/// </summary>
public class UvgaImageContent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaImageContent"/> class.
    /// </summary>
    /// <param name="name">The internal UVGI name of the image.</param>
    /// <param name="pngImageData">The png image byte data.</param>
    /// <exception cref="System.FormatException">If the image data is not valid PNG image data.</exception>
    public UvgaImageContent(string name, IReadOnlyCollection<byte> pngImageData)
    {
        var props = PngImageProperties.Parse(pngImageData);
        if (!props.IsSupported)
        {
            throw new System.FormatException("The image data is not valid PNG image data.");
        }

        this.Name = name;
        this.PngImageData = pngImageData;
    }

    /// <summary>
    /// Gets the name of the image.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the data of the image.
    /// </summary>
    /// <remarks>This is usually PNG image data.</remarks>
    public IReadOnlyCollection<byte> PngImageData { get; }
}
