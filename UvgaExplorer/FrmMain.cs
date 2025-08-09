// <copyright file="FrmMain.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.ComponentModel;
using LibUvgaFile;

/// <summary>
/// Defines the main form of the program.
/// </summary>
internal partial class FrmMain
    : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FrmMain"/> class.
    /// </summary>
    public FrmMain()
    {
        this.InitializeComponent();
        this.uvgaFileExplorer1.ImageEditing += this.UvgaFileExplorer1_ImageEditing;
        this.uvgaFileExplorer1.ImageEdited += this.UvgaFileExplorer1_ImageEdited;
    }

    private void UvgaFileExplorer1_ImageEdited(object? sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Normal;
    }

    private void UvgaFileExplorer1_ImageEditing(object? sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }
}
