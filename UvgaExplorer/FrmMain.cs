// <copyright file="FrmMain.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.Text;
using LibUvgaFile;

/// <summary>
/// Defines the main form of the program.
/// </summary>
internal partial class FrmMain
    : Form
{
    private string currentPath = string.Empty;
    private UvgaCollection? currentFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmMain"/> class.
    /// </summary>
    public FrmMain()
    {
        this.InitializeComponent();
        this.UpdateTitle();
        this.listView1.SelectedIndexChanged += this.ListView1_SelectedIndexChanged;
        this.listView1.MouseDoubleClick += this.ListView1_MouseDoubleClick;
        this.bgwEditItem1.RunWorkerCompleted += this.BgwEditItem_RunWorkerCompleted;
    }

    private void ShowSelectionDetails()
    {
        var items = this.listView1.SelectedItems;
        if (items.Count == 0)
        {
            this.detailView1.Display(null);
            return;
        }

        if (this.listView1.SelectedItems[0] is not DisplayWrapper item || item.SourceItem == null)
        {
            this.detailView1.Display(null);
            return;
        }

        this.detailView1.Display(item.SourceItem);
    }

    private void OpenFile()
    {
        using var dlg = new OpenFileDialog();
        dlg.Filter = "UVGA/I Files|*.uvgi;*.uvga";
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                var uvga = UvgaFile.Load(dlg.FileName);
                var collection = new UvgaCollection(uvga);

                this.currentPath = dlg.FileName;
                this.currentFile?.Dispose();
                this.currentFile = collection;
                this.ShowUvgaFile(collection);
                this.UpdateTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error: {ex}");
            }
        }
    }

    private void UpdateTitle()
    {
        if (string.IsNullOrEmpty(this.currentPath))
        {
            this.Text = "AO GUI Graphics Browser";
        }
        else
        {
            var pathParts = this.currentPath.Split(Path.DirectorySeparatorChar);
            var listPath = string.Join(Path.DirectorySeparatorChar, pathParts[^3..]);
            this.Text = "AO GUI Graphics Browser - " + listPath;
        }
    }

    private void SaveFile()
    {
        if (string.IsNullOrEmpty(this.currentPath))
        {
            this.SaveFileAs();
            return;
        }

        this.SaveFileUnder(this.currentPath);
    }

    private void SaveFileAs()
    {
        using var sfd = new SaveFileDialog();
        sfd.InitialDirectory = Path.GetDirectoryName(this.currentPath);
        sfd.FileName = this.currentPath;
        if (sfd.ShowDialog(this) == DialogResult.Cancel)
        {
            return;
        }

        this.SaveFileUnder(sfd.FileName);
    }

    private void SaveFileUnder(string filename)
    {
        if (string.IsNullOrEmpty(filename) || this.currentFile == null)
        {
            return;
        }

        try
        {
            var target = new UvgaFile();
            target.Images.AddRange(this.currentFile.Select(f => f.Source));
            target.Save(filename, true);
            this.currentPath = filename;
            this.ShowUvgaFile(this.currentFile);
            this.UpdateTitle();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Failed to save the file: {ex.Message}", "Saving failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ImportFiles(IEnumerable<string> files)
    {
        if (this.currentFile == null)
        {
            return;
        }

        var allok = true;
        foreach (var file in files)
        {
            try
            {
                var fn = Path.GetFileNameWithoutExtension(file);
                var data = File.ReadAllBytes(file);
                var rawimgfile = new UvgaImageContent(fn, data);
                var imgFile = new UvgaImageFile(rawimgfile);
                this.ReplaceImage(imgFile);
            }
            catch (Exception)
            {
                allok = false;
                continue;
            }
        }

        this.ShowUvgaFile(this.currentFile);

        if (!allok)
        {
            MessageBox.Show(this, "Failed to import some of the images for whatever reason. Please check that only image files were selected.", "Could not import all images", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ReplaceImage(UvgaImageFile newFile)
    {
        if (this.currentFile == null)
        {
            return;
        }

        var fn = newFile.Name;
        var existingImg = this.currentFile.FirstOrDefault(f => f.Name == fn);
        if (existingImg != null)
        {
            var idx = this.currentFile.IndexOf(existingImg);
            this.currentFile[idx] = newFile;
            existingImg.Dispose();
        }
        else
        {
            this.currentFile.Add(newFile);
        }
    }

    private void ExportSelectedImages()
    {
        var selected = this.listView1.SelectedItems.Cast<DisplayWrapper>().ToList();
        if (selected.Count > 0)
        {
            using var fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var hasExisting = false;
            foreach (var item in selected)
            {
                var sourceName = ((DisplayWrapper)item).SourceItem.Name;
                var fn = Path.Combine(fbd.SelectedPath, sourceName + ".png");
                if (File.Exists(fn))
                {
                    hasExisting = true;
                    break;
                }
            }

            bool overwrite = true;
            if (hasExisting)
            {
                var sb = new StringBuilder();
                sb.AppendLine("The selected folder contains one or more images already. Do you want to overwrite them?");
                sb.AppendLine("[Yes] Overwrite the files");
                sb.AppendLine("[No] Don't overwrite existing files");
                sb.AppendLine("[Cancel] Cancel the export entirely");

                var dlg = MessageBox.Show(this, sb.ToString(), "Files already exist", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.Cancel)
                {
                    return;
                }

                overwrite = dlg == DialogResult.Yes;
            }

            foreach (var item in selected)
            {
                var sourceName = ((DisplayWrapper)item).SourceItem.Name;
                var fn = Path.Combine(fbd.SelectedPath, sourceName + ".png");
                if (File.Exists(fn) && !overwrite)
                {
                    continue;
                }

                File.WriteAllBytes(fn, [.. item.SourceItem.Source.ImageData]);
            }
        }
    }

    private void DeleteSelected()
    {
        if (this.currentFile == null)
        {
            return;
        }

        var selected = this.listView1.SelectedItems.Cast<DisplayWrapper>().ToList();
        if (selected.Count > 0)
        {
            var dlg = MessageBox.Show(this, "Do you want to delete the selected images?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Cancel)
            {
                return;
            }

            foreach (var item in selected)
            {
                this.currentFile.Remove(item.SourceItem);
            }

            this.ShowUvgaFile(this.currentFile);
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

            this.ReplaceImage(res.NewItem);
            this.ShowUvgaFile(this.currentFile);
            var item = this.listView1.Items.Cast<DisplayWrapper>().FirstOrDefault(f => f.SourceItem == res.NewItem);
            if (item != null)
            {
                item.Selected = true;
                item.EnsureVisible();
            }

            this.ShowSelectionDetails();
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
        try
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            this.listView1.LargeImageList?.Dispose();

            var newImages = new ImageList()
            {
                ImageSize = new Size(32, 32),
            };

            foreach (var i in file)
            {
                newImages.Images.Add(i.Name, i.Thumbnail);
                var item = new DisplayWrapper(i)
                {
                    ImageKey = i.Name,
                    ImageIndex = this.listView1.Items.Count,
                };
                this.listView1.Items.Add(item);
            }

            this.listView1.LargeImageList = newImages;
            this.listView1.SmallImageList = newImages;
        }
        finally
        {
            this.listView1.EndUpdate();
        }
    }

    private void CreateNewFile()
    {
        this.currentFile?.Dispose();
        var source = new UvgaFile();
        this.currentFile = new UvgaCollection(source);
        this.currentPath = string.Empty;
        this.ShowUvgaFile(this.currentFile);
        this.UpdateTitle();
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
