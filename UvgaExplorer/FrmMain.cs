// <copyright file="FrmMain.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.Text;
using UvgaExplorer.ImageTransformation;
using UvgaExplorer.ImageTransformation.ScalingTransformation;

/// <summary>
/// Defines the main form of the program.
/// </summary>
internal partial class FrmMain
    : Form
{
    private View currentListeViewStyle = View.LargeIcon;

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmMain"/> class.
    /// </summary>
    public FrmMain()
    {
        this.InitializeComponent();
        this.currentListeViewStyle = (View)Program.UESettings.ListViewStyle;
        this.NewEditor();
        this.TcEditors.SelectedIndexChanged += this.TcEditors_SelectedIndexChanged;
        this.TcEditors.AllowDrop = true;
        this.TcEditors.DragOver += this.TcEditors_DragOver;
        var viewItems = Enum.GetValues(typeof(View));
        foreach (View value in viewItems)
        {
            var btn = new ToolStripMenuItem(value.ToString().Replace("Icon", " Icon"))
            {
                Tag = value,
                Checked = this.currentListeViewStyle == value,
            };
            this.BtnListStyle.DropDownItems.Add(btn);
            btn.Click += this.BtnSetListView_Click;
        }

        this.UpdateUI();
    }

    private CustomEditorTab? SelectedTab
    {
        get
        {
            var t = this.TcEditors.SelectedTab as CustomEditorTab;
            return t;
        }
    }

    private void RunTransformer(IImageTransformer transformer)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.RunImageTransformation(transformer);
    }

    private void TcEditors_SelectedIndexChanged(object? sender, EventArgs e)
    {
        this.UpdateUI();
    }

    private void BtnSetListView_Click(object? sender, EventArgs e)
    {
        if (sender is not ToolStripMenuItem btn || btn.Tag is not View view)
        {
            return;
        }

        this.currentListeViewStyle = view;
        Program.UESettings.ListViewStyle = (int)view;
        Program.UESettings.Save();
        foreach (CustomEditorTab t in this.TcEditors.TabPages)
        {
            t.FileExplorer.SetListViewStyle(view);
        }

        this.UpdateUI();
    }

    private void UpdateUI()
    {
        var t = this.SelectedTab;
        var hasFile = t != null;
        if (!hasFile)
        {
            this.Text = "AO GUI Graphics Browser";
        }
        else
        {
            this.Text = "AO GUI Graphics Browser - " + t!.Text;
        }

        this.BtnCloseFile.Enabled = hasFile;
        this.BtnTsClose.Enabled = hasFile;
        this.BtnSave.Enabled = hasFile;
        this.BtnTsSave.Enabled = hasFile;
        this.BtnSaveAs.Enabled = hasFile;
        this.BtnImportImages.Enabled = hasFile;
        this.BtnExportImages.Enabled = hasFile;
        this.EditMenu.Enabled = hasFile;
        this.BtnTsDeleteSelected.Enabled = hasFile;
        this.BtnTsCopy.Enabled = hasFile;
        this.BtnTsCut.Enabled = hasFile;
        this.BtnTsPaste.Enabled = hasFile;

        this.BtnAutomaticBackups.Checked = Program.UESettings.MakeSaveBackups;
        foreach (ToolStripMenuItem btn in this.BtnListStyle.DropDownItems)
        {
            var tag = btn.Tag as View?;
            if (tag.HasValue && tag.Value == this.currentListeViewStyle)
            {
                btn.Checked = true;
            }
            else
            {
                btn.Checked = false;
            }
        }
    }

    private void NewEditor(UvgaCollection? newFile = null)
    {
        var tab = new CustomEditorTab(this.UvgaFileExplorer1_ImageEditing, this.UvgaFileExplorer1_ImageEdited);
        tab.FileExplorer.SetListViewStyle(this.currentListeViewStyle);
        if (newFile != null)
        {
            tab.FileExplorer.SetActiveFile(newFile);
        }

        var current = this.SelectedTab;
        if (current != null && current.FileExplorer.IsIdle)
        {
            this.CloseEditor();
        }

        var n = this.TcEditors.TabCount;
        this.TcEditors.TabPages.Add(tab);
        this.TcEditors.SelectedTab = tab;
        this.UpdateUI();
    }

    private void CloseEditor()
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        var idx = this.TcEditors.TabPages.IndexOf(t);
        idx--;
        this.TcEditors.TabPages.Remove(t);
        t.Dispose();

        if (idx >= 0 && idx < this.TcEditors.TabCount)
        {
            this.TcEditors.SelectedIndex = idx;
        }

        this.UpdateUI();
    }

    private void UvgaFileExplorer1_ImageEdited(object? sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Normal;
    }

    private void UvgaFileExplorer1_ImageEditing(object? sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void BtnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void BtnAbout_Click(object sender, EventArgs e)
    {
        using var frm = new FrmAbout();
        frm.ShowDialog(this);
    }

    private void BtnNew_Click(object sender, EventArgs e)
    {
        this.NewEditor();
    }

    private void BtnOpen_Click(object sender, EventArgs e)
    {
        var newFile = UvgaOperations.OpenFile(this);
        if (newFile != null)
        {
            this.NewEditor(newFile);
            this.UpdateUI();
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoSave();
        this.UpdateUI();
    }

    private void BtnSaveAs_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoSaveAs();
        this.UpdateUI();
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        this.CloseEditor();
    }

    private void BtnHelp_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Step 1: Open UVGA File");
        sb.AppendLine("Step 2: ???");
        sb.AppendLine("Step 3: Profit!");
        sb.AppendLine();
        sb.AppendLine(@"You can find the files in %localappdata\Funcom\Anarchy Online\<hash>\Folder Name\Gui, or in installation directory\Gui");
        MessageBox.Show(this, sb.ToString(), "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnDeleteSelected_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoDeleteSelected();
    }

    private void BtnCut_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoCutSelected();
    }

    private void BtnCopy_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoCopyItems();
    }

    private void BtnPaste_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoPasteItems();
    }

    private void BtnSelectAll_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoSelectAll();
    }

    private void BtnImportImages_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoImportFiles();
    }

    private void BtnExportImages_Click(object sender, EventArgs e)
    {
        var t = this.SelectedTab;
        if (t == null)
        {
            return;
        }

        t.FileExplorer.DoExportFiles();
    }

    private void TcEditors_DragOver(object? sender, DragEventArgs e)
    {
        var ctrlCoord = this.TcEditors.PointToClient(new Point(e.X, e.Y));
        for (var i = 0; i < this.TcEditors.TabCount; i++)
        {
            var rect = this.TcEditors.GetTabRect(i);
            if (rect.Contains(ctrlCoord))
            {
                this.TcEditors.SelectedIndex = i;
                break;
            }
        }
    }

    private void BtnAutomaticBackups_Click(object sender, EventArgs e)
    {
        Program.UESettings.MakeSaveBackups = !Program.UESettings.MakeSaveBackups;
        Program.UESettings.Save();
        this.BtnAutomaticBackups.Checked = Program.UESettings.MakeSaveBackups;
    }

    private void BtnScaleImages_Click(object sender, EventArgs e)
    {
        this.RunTransformer(new ImageScalingTransformation());
    }

    private class CustomEditorTab
        : TabPage
    {
        private readonly UvgaFileExplorer ctrl;

        public CustomEditorTab(EventHandler handleImageEditing, EventHandler handleImageEdited)
        {
            this.ctrl = new UvgaFileExplorer();
            this.ctrl.ImageEditing += handleImageEditing;
            this.ctrl.ImageEdited += handleImageEdited;
            this.ctrl.TextChanged += this.Ctrl_TextChanged;
            this.Text = this.ctrl.Text;
            this.Controls.Add(this.ctrl);
            this.ctrl.Dock = DockStyle.Fill;
        }

        public UvgaFileExplorer FileExplorer { get => this.ctrl; }

        private void Ctrl_TextChanged(object? sender, EventArgs e)
        {
            this.Text = this.ctrl.Text;
        }
    }
}
