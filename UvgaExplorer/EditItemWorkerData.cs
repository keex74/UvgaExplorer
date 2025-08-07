// <copyright file="EditItemWorkerData.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

/// <summary>
/// Defines a class that contains work data for the <see cref="BgwEditItem"/> worker.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EditItemWorkerData"/> class.
/// </remarks>
/// <param name="item">The source image file.</param>
internal class EditItemWorkerData(UvgaImageFile item)
{
    /// <summary>
    /// Gets or sets a value indicating whether the editing was successful.
    /// </summary>
    public bool Success { get; set; } = false;

    /// <summary>
    /// Gets the source image item.
    /// </summary>
    public UvgaImageFile Item { get; } = item;

    /// <summary>
    /// Gets or sets the item that replaces the source item.
    /// </summary>
    public UvgaImageFile? NewItem { get; set; }
}
