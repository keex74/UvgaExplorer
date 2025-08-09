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
    private UvgaCollection? currentFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmMain"/> class.
    /// </summary>
    public FrmMain()
    {
        this.InitializeComponent();
        this.CreateNewFile();
        this.uvgaListDisplay1.ImageDoubleClicked += this.UvgaListDisplay1_ImageDoubleClicked;
        this.uvgaListDisplay1.ActiveImageChanged += this.UvgaListDisplay1_ActiveImageChanged;
        this.uvgaListDisplay1.ImageImportRequested += this.UvgaListDisplay1_ImageImportRequested;
        this.bgwEditItem1.RunWorkerCompleted += this.BgwEditItem_RunWorkerCompleted;
    }

    private void BgwEditItem_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        var res = e.Result as EditItemWorkerData;
        this.FinishItemEdit(res);
    }

    private void UvgaListDisplay1_ImageDoubleClicked(object? sender, ImageItemsEventArgs e)
    {
        if (e.Images.Count > 0)
        {
            this.EditFile(e.Images[0]);
        }
    }

    private void UvgaListDisplay1_ActiveImageChanged(object? sender, EventArgs e)
    {
        var image = this.uvgaListDisplay1.ActiveImage;
        this.detailView1.Display(image);
    }

    private void UvgaListDisplay1_ImageImportRequested(object? sender, FileDropEventArgs e)
    {
        if (this.currentFile == null)
        {
            return;
        }

        UvgaOperations.ImportImages(this, this.currentFile, e.FileNames);
        this.ShowUvgaFile(this.currentFile);
    }

    private void OpenToolStripButton_Click(object sender, EventArgs e)
    {
        var newFile = UvgaOperations.OpenFile(this);
        if (newFile != null)
        {
            this.currentFile?.Dispose();
            this.currentFile = newFile;
            this.ShowUvgaFile(this.currentFile);
            this.UpdateTitle();
        }
    }

    private void SaveToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.currentFile == null)
        {
            return;
        }

        UvgaOperations.SaveFileAs(this, this.currentFile);
        this.UpdateTitle();
    }

    private void NewToolStripButton_Click(object sender, EventArgs e)
    {
        this.CreateNewFile();
    }

    private void CopyToolStripButton_Click(object sender, EventArgs e)
    {
        var selected = this.uvgaListDisplay1.SelectedImages;
        UvgaOperations.ExportSelectedImages(this, selected);
    }

    private void BtnDeleteSelected_Click(object sender, EventArgs e)
    {
        if (this.currentFile == null)
        {
            return;
        }

        var selected = this.uvgaListDisplay1.SelectedImages;
        UvgaOperations.DeleteSelected(this, this.currentFile, selected);
        this.ShowUvgaFile(this.currentFile);
    }

    private void PasteToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.currentFile == null)
        {
            return;
        }

        using var ofd = new OpenFileDialog();
        ofd.Filter = "PNG Files|*.png";
        ofd.Multiselect = true;
        if (ofd.ShowDialog(this) == DialogResult.Cancel)
        {
            return;
        }

        UvgaOperations.ImportImages(this, this.currentFile, ofd.FileNames);
        this.ShowUvgaFile(this.currentFile);
    }

    private void BtnAbout_Click(object sender, EventArgs e)
    {
        using var frm = new FrmAbout();
        frm.ShowDialog(this);
    }

    private void UpdateTitle()
    {
        if (this.currentFile == null)
        {
            this.Text = "AO GUI Graphics Browser - No file";
            this.uvgaListDisplay1.Enabled = false;
        }
        else if (string.IsNullOrEmpty(this.currentFile.SourcePath))
        {
            this.Text = "AO GUI Graphics Browser - New file";
            this.uvgaListDisplay1.Enabled = true;
        }
        else
        {
            var pathParts = this.currentFile.SourcePath.Split(Path.DirectorySeparatorChar);
            var listPath = string.Join(Path.DirectorySeparatorChar, pathParts[^3..]);
            this.Text = "AO GUI Graphics Browser - " + listPath;
            this.uvgaListDisplay1.Enabled = true;
        }
    }

    private void EditFile(UvgaImageFile file)
    {
        if (this.bgwEditItem1.IsBusy)
        {
            return;
        }

        var data = new EditItemWorkerData(file);
        this.Enabled = false;
        this.Text = $"Editing item {file.Source.Name}...";
        this.bgwEditItem1.RunWorkerAsync(data);
        this.WindowState = FormWindowState.Minimized;
    }

    private void FinishItemEdit(EditItemWorkerData? res)
    {
        try
        {
            if (res == null)
            {
                return;
            }

            if (!res.Success || res.NewItem == null || this.currentFile == null)
            {
                res.NewItem?.Dispose();
                return;
            }

            UvgaOperations.ReplaceImage(this.currentFile, res.NewItem);
            this.ShowUvgaFile(this.currentFile);
            this.uvgaListDisplay1.ActiveImage = res.NewItem;
        }
        finally
        {
            this.Enabled = true;
            this.UpdateTitle();
            this.WindowState = FormWindowState.Normal;
        }
    }

    private void ShowUvgaFile(UvgaCollection file)
    {
        this.uvgaListDisplay1.Initialize(file);
    }

    private void CreateNewFile()
    {
        this.currentFile?.Dispose();
        var source = new UvgaFile();
        this.currentFile = new UvgaCollection(source);
        this.ShowUvgaFile(this.currentFile);
        this.UpdateTitle();
    }
}
