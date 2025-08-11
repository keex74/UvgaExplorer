// <copyright file="UvgaFileExplorer.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.ComponentModel;
using System.Windows.Forms;
using LibUvgaFile;
using UvgaExplorer.ImageTransformation;

/// <summary>
/// Defines a complete edit control for UVGA files.
/// </summary>
internal partial class UvgaFileExplorer
    : UserControl
{
    private UvgaCollection? currentFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaFileExplorer"/> class.
    /// </summary>
    public UvgaFileExplorer()
    {
        this.InitializeComponent();
        this.CreateNewFile();
        this.uvgaListDisplay1.ImageDoubleClicked += this.UvgaListDisplay1_ImageDoubleClicked;
        this.uvgaListDisplay1.ActiveImageChanged += this.UvgaListDisplay1_ActiveImageChanged;
        this.uvgaListDisplay1.ImageImportRequested += this.UvgaListDisplay1_ImageImportRequested;
        this.uvgaListDisplay1.DeleteImagesRequested += this.UvgaListDisplay1_DeleteImagesRequested;
        this.bgwEditItem1.RunWorkerCompleted += this.BgwEditItem_RunWorkerCompleted;
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
    /// Gets a value indicating whether the editor is not saved and also empty.
    /// </summary>
    public bool IsIdle { get => this.currentFile == null || (string.IsNullOrEmpty(this.currentFile.SourcePath) && this.currentFile.Count == 0); }

    /// <summary>
    /// Set the file that is displayed on the control.
    /// </summary>
    /// <param name="newFile">The file.</param>
    public void SetActiveFile(UvgaCollection newFile)
    {
        if (newFile != null)
        {
            this.currentFile?.Dispose();
            newFile.SortList();
            this.currentFile = newFile;
            this.ShowUvgaFile(this.currentFile);
            this.UpdateTitle();
        }
    }

    /// <summary>
    /// Perform saving of the file.
    /// </summary>
    public void DoSave()
    {
        if (this.currentFile == null)
        {
            return;
        }

        UvgaOperations.SaveFile(this, this.currentFile);
        this.UpdateTitle();
    }

    /// <summary>
    /// Perform saving of the file as.
    /// </summary>
    public void DoSaveAs()
    {
        if (this.currentFile == null)
        {
            return;
        }

        UvgaOperations.SaveFileAs(this, this.currentFile);
        this.UpdateTitle();
    }

    /// <summary>
    /// Remove the selected items.
    /// </summary>
    public void DoDeleteSelected()
    {
        if (this.currentFile == null)
        {
            return;
        }

        var selected = this.uvgaListDisplay1.SelectedImages;
        UvgaOperations.DeleteSelected(this, this.currentFile, selected);
        this.ShowUvgaFile(this.currentFile);
    }

    /// <summary>
    /// Cut the selected items.
    /// </summary>
    public void DoCutSelected()
    {
        if (this.currentFile == null)
        {
            return;
        }

        this.uvgaListDisplay1.CopySelectedImagesToClipboard();
        var selected = this.uvgaListDisplay1.SelectedImages;
        UvgaOperations.DeleteSelected(this, this.currentFile, selected, false);
        this.ShowUvgaFile(this.currentFile);
    }

    /// <summary>
    /// Copy the selected items.
    /// </summary>
    public void DoCopyItems()
    {
        if (this.currentFile == null)
        {
            return;
        }

        this.uvgaListDisplay1.CopySelectedImagesToClipboard();
    }

    /// <summary>
    /// Paste the selected items.
    /// </summary>
    public void DoPasteItems()
    {
        if (this.currentFile == null)
        {
            return;
        }

        this.uvgaListDisplay1.PasteItemsFromClipboard();
    }

    /// <summary>
    /// Import selected images files.
    /// </summary>
    public void DoImportFiles()
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
        this.currentFile.SortList();
        this.ShowUvgaFile(this.currentFile);
    }

    /// <summary>
    /// Export selected image files.
    /// </summary>
    public void DoExportFiles()
    {
        var selected = this.uvgaListDisplay1.SelectedImages;
        UvgaOperations.ExportSelectedImages(this, selected);
    }

    /// <summary>
    /// Set the list view style.
    /// </summary>
    /// <param name="style">The style.</param>
    public void SetListViewStyle(View style)
    {
        this.uvgaListDisplay1.Liststyle = style;
    }

    /// <summary>
    /// Select all images.
    /// </summary>
    public void DoSelectAll()
    {
        this.uvgaListDisplay1.SelectAll();
    }

    /// <summary>
    /// Run an image transformation on the currently selected images.
    /// </summary>
    /// <param name="transformer">The transformer to run.</param>
    public void RunImageTransformation(IImageTransformer transformer)
    {
        if (this.currentFile == null)
        {
            return;
        }

        var selected = this.uvgaListDisplay1.SelectedImages;
        if (selected.Count == 0)
        {
            return;
        }

        using var ctrl = transformer.GetConfigurationControl();
        if (ctrl != null)
        {
            using var frm = new TransformationSetupForm();
            frm.Initialize(ctrl);
            var dlg = frm.ShowDialog(this);
            if (dlg != DialogResult.OK)
            {
                return;
            }
        }

        foreach (var img in selected)
        {
            var newimage = transformer.TransformImage(img.Image, ctrl);
            if (newimage == null)
            {
                continue;
            }

            // Potentially fix the pixel format if the image didn't take care of it.
            if (newimage.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            {
                var bmpFixed = new Bitmap(newimage.Width, newimage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                bmpFixed.SetResolution(newimage.HorizontalResolution, newimage.VerticalResolution);
                using var g = Graphics.FromImage(bmpFixed);
                g.DrawImageUnscaled(newimage, 0, 0);
                newimage.Dispose();
                newimage = bmpFixed;
            }

            // Replace the image.
            using var ms = new MemoryStream();
            newimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            newimage.Dispose();
            var data = ms.ToArray();
            var replaceImage = new UvgaImageContent(img.Name, data);
            var uvgaimg = new UvgaImageFile(replaceImage);
            UvgaOperations.ReplaceImage(this.currentFile, uvgaimg);
        }

        this.ShowUvgaFile(this.currentFile);
    }

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

        UvgaImageFile? newActive = null;
        if (e.FileNames.Count > 0)
        {
            var newImages = UvgaOperations.ImportImages(this, this.currentFile, e.FileNames);
            newActive = newImages.FirstOrDefault();
        }
        else if (e.Images.Count > 0)
        {
            foreach (var item in e.Images)
            {
                var newitem = new UvgaImageFile(item);
                newActive ??= newitem;
                UvgaOperations.ReplaceImage(this.currentFile, newitem);
            }
        }

        this.currentFile.SortList();
        this.ShowUvgaFile(this.currentFile);
        this.uvgaListDisplay1.ActiveImage = newActive;
    }

    private void UvgaListDisplay1_DeleteImagesRequested(object? sender, EventArgs e)
    {
        this.DoDeleteSelected();
    }

    private void UpdateTitle()
    {
        if (this.currentFile == null)
        {
            this.Text = "No file";
            this.uvgaListDisplay1.Enabled = false;
        }
        else if (string.IsNullOrEmpty(this.currentFile.SourcePath))
        {
            this.Text = "New file";
            this.uvgaListDisplay1.Enabled = true;
        }
        else
        {
            var pathParts = this.currentFile.SourcePath.Split(Path.DirectorySeparatorChar);
            var listPath = string.Join(Path.DirectorySeparatorChar, pathParts[^3..]);
            this.Text = listPath;
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
