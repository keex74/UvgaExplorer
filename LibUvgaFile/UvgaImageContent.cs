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
/// <remarks>
/// Initializes a new instance of the <see cref="UvgaImageContent"/> class.
/// </remarks>
/// <param name="name">The internal UVGI name of the image.</param>
/// <param name="imageData">The image byte data.</param>
public class UvgaImageContent(string name, IReadOnlyCollection<byte> imageData)
{
    /// <summary>
    /// Gets the name of the image.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Gets the data of the image.
    /// </summary>
    /// <remarks>This is usually PNG image data.</remarks>
    public IReadOnlyCollection<byte> ImageData { get; } = imageData;
}
