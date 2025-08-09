// <copyright file="UvgaFileExplorer.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.ComponentModel;
using LibUvgaFile;

/// <summary>
/// Defines a complete edit control for UVGA files.
/// </summary>
public partial class UvgaFileExplorer
    : UserControl
{
    private UvgaCollection? currentFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaFileExplorer"/> class.
    /// </summary>
    public UvgaFileExplorer()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Raised when an image is started being externally edited.
    /// </summary>
    public event EventHandler? ImageEditing;

    /// <summary>
    /// Raised when image was finished being edited externally.
    /// </summary>
    public event EventHandler? ImageEdited;

    /// <summary>
    /// Raises the <see cref="ImageEditing"/> event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected void OnImageEditing(EventArgs e)
    {
        this.ImageEditing?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ImageEdited"/> event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected void OnImageEdited(EventArgs e)
    {
        this.ImageEdited?.Invoke(this, e);
    }

    private void SetListViewStyle(object? sender, EventArgs e)
    {
        if (sender is not ToolStripMenuItem btn || btn.Tag is not View view)
        {
            return;
        }

        this.uvgaListDisplay1.Liststyle = view;
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

        if (e.FileNames.Count > 0)
        {
            UvgaOperations.ImportImages(this, this.currentFile, e.FileNames);
        }
        else if (e.Images.Count > 0)
        {
            foreach (var item in e.Images)
            {
                var newitem = new UvgaImageFile(item);
                UvgaOperations.ReplaceImage(this.currentFile, newitem);
            }
        }

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
        this.OnImageEditing(EventArgs.Empty);
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
            this.OnImageEdited(EventArgs.Empty);
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
