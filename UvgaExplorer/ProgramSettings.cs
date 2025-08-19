// <copyright file="ProgramSettings.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

/// <summary>
/// Defines program settings.
/// </summary>
internal class ProgramSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether backups are made on saving.
    /// </summary>
    public bool MakeSaveBackups { get; set; } = true;

    /// <summary>
    /// Gets or sets the listview style.
    /// </summary>
    public int ListViewStyle { get; set; } = (int)View.Details;

    /// <summary>
    /// Gets or sets the program to run when a file is to be edited.
    /// </summary>
    public string OpenWithFilename { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the arguments to use when opening an image.
    /// </summary>
    /// <remarks>%1 in the arguments is replaced with the full path of the image to be edited.</remarks>
    public string OpenWithArguments { get; set; } = "\"%1\"";

    /// <summary>
    /// Save the settings.
    /// </summary>
    public void Save()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(this);
        Properties.Settings.Default.ProgramSettings = json;
        Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Restore the settings.
    /// </summary>
    public void Restore()
    {
        if (!Properties.Settings.Default.IsUpgraded)
        {
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.IsUpgraded = true;
            Properties.Settings.Default.Save();
        }

        var json = Properties.Settings.Default.ProgramSettings;
        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                var settings = System.Text.Json.JsonSerializer.Deserialize<ProgramSettings>(json);
                if (settings != null)
                {
                    this.MakeSaveBackups = settings.MakeSaveBackups;
                    this.ListViewStyle = settings.ListViewStyle;
                    this.OpenWithArguments = settings.OpenWithArguments;
                    this.OpenWithFilename = settings.OpenWithFilename;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
