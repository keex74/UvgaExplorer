// <copyright file="DblBufferedListView.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

/// <summary>
/// Implements a listview with double-buffering.
/// </summary>
internal class DblBufferedListView
    : ListView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DblBufferedListView"/> class.
    /// </summary>
    public DblBufferedListView()
        : base()
    {
        this.DoubleBuffered = true;
    }
}
