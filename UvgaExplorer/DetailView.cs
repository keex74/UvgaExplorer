// <copyright file="DetailView.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.Diagnostics;
using System.Drawing.Imaging;

/// <summary>
/// Defines a control that displays details about an image.
/// </summary>
internal partial class DetailView
    : UserControl
{
    private UvgaImageFile? image;

    /// <summary>
    /// Initializes a new instance of the <see cref="DetailView"/> class.
    /// </summary>
    public DetailView()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Display the given file.
    /// </summary>
    /// <param name="file">The image file.</param>
    public void Display(UvgaImageFile? file)
    {
        this.image = file;

        if (file == null)
        {
            this.pictureBox1.Image = null;
            this.TbFilename.Text = string.Empty;
            this.TbFilename.Text = string.Empty;
            this.TbFilename.Text = string.Empty;
            this.BtnSaveImage.Enabled = false;
            return;
        }

        this.BtnSaveImage.Enabled = true;
        this.pictureBox1.Image = file.Image;
        this.TbFilename.Text = file.Name;
        this.TbImageSize.Text = $"{file.Image.Width} x {file.Image.Height}";
        this.TbImageFormat.Text = file.Image.PixelFormat.ToString();
    }

    private void SaveImage()
    {
        if (this.image == null)
        {
            return;
        }

        using var dlg = new SaveFileDialog();
        dlg.Filter = "PNG Files|*.png";
        dlg.FileName = this.image.Name + ".png";
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                this.image.Image.Save(dlg.FileName, ImageFormat.Png);
                var psi = new ProcessStartInfo(dlg.FileName)
                {
                    UseShellExecute = true,
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Saving the file failed:{Environment.NewLine}{ex}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BtnSaveImage_Click(object sender, EventArgs e)
    {
        this.SaveImage();
    }
}
