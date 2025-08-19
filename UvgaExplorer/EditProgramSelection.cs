// <copyright file="EditProgramSelection.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

/// <summary>
/// Defines a dialog to edit the open with program.
/// </summary>
public partial class EditProgramSelection
    : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EditProgramSelection"/> class.
    /// </summary>
    public EditProgramSelection()
    {
        this.InitializeComponent();
        this.TbProgramPath.Text = Program.UESettings.OpenWithFilename;
        this.TbArguments.Text = Program.UESettings.OpenWithArguments;
    }

    private void BtnSearchFile_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "Executables|*.exe;*.bat;*.ps;*.com;*.sh";
        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
            this.TbProgramPath.Text = ofd.FileName;
        }
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
        Program.UESettings.OpenWithFilename = this.TbProgramPath.Text;
        Program.UESettings.OpenWithArguments = this.TbArguments.Text;
        Program.UESettings.Save();
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
