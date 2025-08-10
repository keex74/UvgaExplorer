// <copyright file="PngColorType.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace LibUvgaFile;

/// <summary>
/// Defines the png color type in the image.
/// </summary>
public enum PngColorType
{
    /// <summary>
    /// Grayscale samples.
    /// </summary>
    Grayscale = 0,

    /// <summary>
    /// RGB triples.
    /// </summary>
    RGB = 2,

    /// <summary>
    /// Palette indizes.
    /// </summary>
    Palette = 3,

    /// <summary>
    /// Grayscale samples with alpha sample.
    /// </summary>
    GrayscaleAlpha = 4,

    /// <summary>
    /// RGB triples with alpha sample.
    /// </summary>
    RGBA = 6,

    /// <summary>
    /// The color type has an invalid value.
    /// </summary>
    Invalid = 255,
}
