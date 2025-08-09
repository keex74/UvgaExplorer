// <copyright file="FileDropEventArgs.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using LibUvgaFile;

/// <summary>
/// Defines arguments for image based list events.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ImageItemsEventArgs"/> class.
/// </remarks>
/// <param name="fileNames">The filenames related to the event.</param>
/// <param name="images">Any direct items that were part of the event.</param>
internal class FileDropEventArgs(IReadOnlyList<string> fileNames, IReadOnlyList<UvgaImageContent> images)
        : EventArgs
{
    /// <summary>
    /// Gets the filenames that were part of the drop related to the event.
    /// </summary>
    public IReadOnlyList<string> FileNames { get; } = fileNames;

    /// <summary>
    /// Gets the images that were part of the drop.
    /// </summary>
    public IReadOnlyList<UvgaImageContent> Images { get; } = images;
}
