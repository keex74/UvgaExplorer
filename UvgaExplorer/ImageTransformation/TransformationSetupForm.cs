// <copyright file="TransformationSetupForm.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ImageTransformation;

/// <summary>
/// A form to display transformation forms.
/// </summary>
public partial class TransformationSetupForm
    : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransformationSetupForm"/> class.
    /// </summary>
    public TransformationSetupForm()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Initialize the form with the given control.
    /// </summary>
    /// <param name="control">The control to show.</param>
    public void Initialize(Control control)
    {
        this.panel1.Controls.Add(control);
        control.Dock = DockStyle.Fill;
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
