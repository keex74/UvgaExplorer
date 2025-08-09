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
    private UvgaCollection currentimages;

    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaListDisplay"/> class.
    /// </summary>
    public UvgaListDisplay()
    {
        this.InitializeComponent();
        var newfile = new UvgaFile();
        this.currentimages = new UvgaCollection(newfile);
        this.LvImages.MouseDoubleClick += this.LvImages_MouseDoubleClick;
        this.LvImages.KeyDown += this.LvImages_KeyDown;
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
    /// Gets or sets the currently active image.
    /// </summary>
    public UvgaImageFile? ActiveImage { get => this.GetActiveImage(); set => this.SetActiveImage(value); }

    /// <summary>
    /// Gets or sets the currently selected images.
    /// </summary>
    public IReadOnlyCollection<UvgaImageFile> SelectedImages { get => this.GetSelectedImages(); set => this.SetSelectedImages(value); }

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

            foreach (var i in images)
            {
                newImages.Images.Add(i.Name, i.Thumbnail);
                var item = new DisplayWrapper(i)
                {
                    ImageKey = i.Name,
                    ImageIndex = this.LvImages.Items.Count,
                };
                this.LvImages.Items.Add(item);
            }

            this.LvImages.LargeImageList = newImages;
            this.LvImages.SmallImageList = newImages;

            this.LblImageCount.Text = $"{images.Count} images";
        }
        finally
        {
            this.LvImages.EndUpdate();
            this.LvImages.AutoScrollOffset = scrollPosition;
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

    private void LvImages_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        var ht = this.LvImages.HitTest(e.Location);
        if (ht.Item is DisplayWrapper dw)
        {
            var item = dw.SourceItem;
            this.OnImageDoubleClicked(new ImageItemsEventArgs([item]));
        }
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

    private class DisplayWrapper
        : ListViewItem
    {
        private readonly UvgaImageFile image;

        public DisplayWrapper(UvgaImageFile img)
        {
            this.image = img;
            this.Text = img.Name;
            this.SourceItem = img;
        }

        public UvgaImageFile SourceItem { get; }
    }
}
