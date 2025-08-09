// <copyright file="Program.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

/// <summary>
/// Contains the main entry point of the pgoram.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Gets the program settings.
    /// </summary>
    public static ProgramSettings UESettings { get; } = new();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        ApplicationConfiguration.Initialize();
        UESettings.Restore();
        Application.Run(new FrmMain());
    }
}