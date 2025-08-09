// <copyright file="ImageItemsEventArgs.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

/// <summary>
/// Defines arguments for image based list events.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ImageItemsEventArgs"/> class.
/// </remarks>
/// <param name="images">The images related to the event.</param>
internal class ImageItemsEventArgs(IReadOnlyList<UvgaImageFile> images)
        : EventArgs
{
    /// <summary>
    /// Gets the images related to the event.
    /// </summary>
    public IReadOnlyList<UvgaImageFile> Images { get; } = images;
}
