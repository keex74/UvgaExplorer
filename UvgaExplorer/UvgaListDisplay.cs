// <copyright file="UvgaListDisplay.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using LibUvgaFile;

/// <summary>
/// A control that display a list of UVGA images.
/// </summary>
internal partial class UvgaListDisplay
    : UserControl
{
    private readonly List<UvgaImageFile> selectedOnMouseDown = [];
    private UvgaCollection currentimages;
    private bool mouseDownOnItem = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaListDisplay"/> class.
    /// </summary>
    public UvgaListDisplay()
    {
        this.InitializeComponent();
        var newfile = new UvgaFile();
        this.currentimages = new UvgaCollection(newfile);
        this.LvImages.AllowDrop = true;
        this.LvImages.KeyDown += this.LvImages_KeyDown;
        this.LvImages.DragEnter += this.LvImages_DragEnter;
        this.LvImages.DragDrop += this.LvImages_DragDrop;
        this.LvImages.MouseDown += this.LvImages_MouseDown;
        this.LvImages.MouseUp += this.LvImages_MouseUp;
        this.LvImages.MouseMove += this.LvImages_MouseMove;
        this.LvImages.Columns.Add("Name");
        this.LvImages.Columns.Add("Width");
        this.LvImages.Columns.Add("Height");
        this.LvImages.Columns.Add("Pixel Format");
        this.LvImages.View = View.LargeIcon;
    }

    /// <summary>
    /// Raised when <see cref="ActiveImage"/> changed.
    /// </summary>
    public event EventHandler? ActiveImageChanged;

    /// <summary>
    /// Raised when <see cref="SelectedImages"/> changed.
    /// </summary>
    public event EventHandler? SelectedImagesChanged;

    /// <summary>
    /// Raised when an image was double-clicked.
    /// </summary>
    public event EventHandler<ImageItemsEventArgs>? ImageDoubleClicked;

    /// <summary>
    /// Raised when an image import was requested.
    /// </summary>
    public event EventHandler<FileDropEventArgs>? ImageImportRequested;

    /// <summary>
    /// Gets or sets the currently active image.
    /// </summary>
    public UvgaImageFile? ActiveImage { get => this.GetActiveImage(); set => this.SetActiveImage(value); }

    /// <summary>
    /// Gets or sets the currently selected images.
    /// </summary>
    public IReadOnlyCollection<UvgaImageFile> SelectedImages { get => this.GetSelectedImages(); set => this.SetSelectedImages(value); }

    /// <summary>
    /// Gets or sets the list style.
    /// </summary>
    public View Liststyle
    {
        get => this.LvImages.View;
        set
        {
            this.LvImages.View = value;
            if (value == View.Details)
            {
                this.LvImages.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                this.LvImages.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                this.LvImages.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
                this.LvImages.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }

    /// <summary>
    /// Initialize the control with the given image collection.
    /// </summary>
    /// <param name="images">The image collection.</param>
    public void Initialize(UvgaCollection images)
    {
        this.currentimages = images;
        this.DisplayImages(this.currentimages);
    }

    /// <summary>
    /// Raises the <see cref="ActiveImageChanged"/> event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected virtual void OnActiveImageChanged(EventArgs e)
    {
        this.ActiveImageChanged?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SelectedImagesChanged"/> event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected virtual void OnSelectedImagesChanged(EventArgs e)
    {
        this.SelectedImagesChanged?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ImageDoubleClicked"/> event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected virtual void OnImageDoubleClicked(ImageItemsEventArgs e)
    {
        this.ImageDoubleClicked?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ImageImportRequested"/> event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected virtual void OnImageImportRequested(FileDropEventArgs e)
    {
        this.ImageImportRequested?.Invoke(this, e);
    }

    private List<UvgaImageFile> GetSelectedImages()
    {
        var res = new List<UvgaImageFile>();
        foreach (DisplayWrapper item in this.LvImages.Items)
        {
            if (item.Selected)
            {
                res.Add(item.SourceItem);
            }
        }

        return res;
    }

    private void SetSelectedImages(IReadOnlyCollection<UvgaImageFile> images)
    {
        try
        {
            this.SetChangeEvent(false);
            this.LvImages.BeginUpdate();
            foreach (DisplayWrapper item in this.LvImages.Items)
            {
                item.Selected = images.Contains(item.SourceItem);
            }
        }
        finally
        {
            this.LvImages.EndUpdate();
            this.OnActiveImageChanged(EventArgs.Empty);
            this.OnSelectedImagesChanged(EventArgs.Empty);
            this.SetChangeEvent(true);
        }
    }

    private UvgaImageFile? GetActiveImage()
    {
        if (this.LvImages.FocusedItem is DisplayWrapper item)
        {
            return item.SourceItem;
        }

        return null;
    }

    private void SetActiveImage(UvgaImageFile? image)
    {
        if (image == null)
        {
            this.LvImages.FocusedItem = null;
            this.OnActiveImageChanged(EventArgs.Empty);
        }
        else
        {
            foreach (DisplayWrapper item in this.LvImages.Items)
            {
                if (item.SourceItem == image)
                {
                    this.LvImages.FocusedItem = item;
                    item.EnsureVisible();
                    this.OnActiveImageChanged(EventArgs.Empty);
                    return;
                }
            }
        }
    }

    private void DisplayImages(UvgaCollection images)
    {
        var scrollPosition = this.LvImages.AutoScrollOffset;

        try
        {
            this.SetChangeEvent(false);
            this.LvImages.BeginUpdate();
            this.LvImages.Items.Clear();
            this.LvImages.LargeImageList?.Dispose();

            var newImages = new ImageList()
            {
                ImageSize = new Size(32, 32),
            };

            var newImagesSmall = new ImageList()
            {
                ImageSize = new Size(16, 16),
            };

            foreach (var i in images)
            {
                newImages.Images.Add(i.Name, i.Thumbnail);
                newImagesSmall.Images.Add(i.Name, i.Thumbnail);
                var item = new DisplayWrapper(i)
                {
                    ImageKey = i.Name,
                    ImageIndex = this.LvImages.Items.Count,
                };
                this.LvImages.Items.Add(item);
            }

            this.LvImages.LargeImageList = newImages;
            this.LvImages.SmallImageList = newImagesSmall;

            this.LblImageCount.Text = $"{images.Count} images";
        }
        finally
        {
            this.LvImages.EndUpdate();
            this.LvImages.AutoScrollOffset = scrollPosition;
            this.LvImages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.OnActiveImageChanged(EventArgs.Empty);
            this.OnSelectedImagesChanged(EventArgs.Empty);
            this.SetChangeEvent(true);
        }
    }

    private void SetChangeEvent(bool enable)
    {
        this.LvImages.ItemSelectionChanged -= this.LvImages_ItemSelectionChanged;
        if (enable)
        {
            this.LvImages.ItemSelectionChanged += this.LvImages_ItemSelectionChanged;
        }
    }

    private void LvImages_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
    {
        this.OnActiveImageChanged(EventArgs.Empty);
        this.OnSelectedImagesChanged(EventArgs.Empty);
    }

    private void LvImages_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            this.LvImages.BeginUpdate();
            foreach (ListViewItem i in this.LvImages.Items)
            {
                i.Selected = true;
            }

            this.LvImages.EndUpdate();
        }
    }

    private void LvImages_DragDrop(object? sender, DragEventArgs e)
    {
        if (e.Data == null || !e.Data.GetDataPresent(DataFormats.FileDrop) || (e.AllowedEffect & DragDropEffects.Copy) == 0)
        {
            return;
        }

        if (e.Data.GetData(DataFormats.FileDrop) is string[] dropdata && dropdata.Length > 0)
        {
            this.OnImageImportRequested(new FileDropEventArgs(dropdata));
        }
    }

    private void LvImages_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data == null)
        {
            return;
        }

        if (e.Data.GetDataPresent(DataFormats.FileDrop) && (e.AllowedEffect & DragDropEffects.Copy) > 0)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }

    private void LvImages_MouseDown(object? sender, MouseEventArgs e)
    {
        // If mouse is pressed on an item, save this for later to initiate a drag&drop operation if the mouse is moved.
        var ht = this.LvImages.HitTest(e.Location);
        if (ht.Item is DisplayWrapper dw)
        {
            if (e.Clicks == 1)
            {
                var selected = this.SelectedImages;
                var toDrop = new List<UvgaImageFile>();
                if (selected != null && selected.Count > 0)
                {
                    toDrop.AddRange(selected);
                }

                if (!toDrop.Contains(dw.SourceItem))
                {
                    toDrop.Add(dw.SourceItem);
                }

                if (toDrop.Count > 0)
                {
                    this.LvImages.AllowDrop = false;
                    this.selectedOnMouseDown.Clear();
                    this.selectedOnMouseDown.AddRange(toDrop);
                    this.mouseDownOnItem = true;
                }
            }
            else if (e.Clicks == 2)
            {
                this.selectedOnMouseDown.Clear();
                this.mouseDownOnItem = false;
                this.OnImageDoubleClicked(new ImageItemsEventArgs([dw.SourceItem]));
            }
        }
    }

    private void LvImages_MouseMove(object? sender, MouseEventArgs e)
    {
        if (this.mouseDownOnItem && this.selectedOnMouseDown.Count > 0)
        {
            // Drag of file out started. Save the files to drop as temp files
            var createdFiles = new List<string>();
            var folder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            try
            {
                Directory.CreateDirectory(folder);
                foreach (var item in this.selectedOnMouseDown)
                {
                    // Images in the UVGA don't have extensions.
                    var fn = item.Source.Name + ".png";
                    var outputFile = Path.Combine(folder, fn);
                    var arr = item.Source.ImageData.ToArray();
                    File.WriteAllBytes(outputFile, arr);
                    createdFiles.Add(outputFile);
                }

                // Perform the drag & drop operation
                var data = new DataObject(DataFormats.FileDrop, createdFiles.ToArray());
                var eff = this.LvImages.DoDragDrop(data, DragDropEffects.Copy | DragDropEffects.Move);
                this.selectedOnMouseDown.Clear();
                this.mouseDownOnItem = false;
                this.LvImages.AllowDrop = false;
            }
            catch (Exception)
            {
                // Well...didn't work :|
            }
            finally
            {
                // Clean up the temp directory
                Directory.Delete(folder, true);
            }
        }
    }

    private void LvImages_MouseUp(object? sender, MouseEventArgs e)
    {
        this.selectedOnMouseDown.Clear();
        this.mouseDownOnItem = false;
        this.LvImages.AllowDrop = true;
    }

    private class DisplayWrapper
        : ListViewItem
    {
        private readonly UvgaImageFile image;

        public DisplayWrapper(UvgaImageFile img)
        {
            this.image = img;
            this.Text = img.Name;
            this.SourceItem = img;
            this.SubItems.Add(img.Image.Width.ToString());
            this.SubItems.Add(img.Image.Height.ToString());
            var pxFormat = img.Image.PixelFormat.ToString();
            this.SubItems.Add(pxFormat.StartsWith("Format") ? pxFormat.Substring(6) : pxFormat);
        }

        public UvgaImageFile SourceItem { get; }
    }
}
