namespace UvgaExplorer;

partial class FrmMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
        this.TcEditors = new TabControl();
        this.menuStrip1 = new MenuStrip();
        this.fileToolStripMenuItem1 = new ToolStripMenuItem();
        this.BtnNew = new ToolStripMenuItem();
        this.BtnOpen = new ToolStripMenuItem();
        this.toolStripSeparator = new ToolStripSeparator();
        this.BtnSave = new ToolStripMenuItem();
        this.BtnSaveAs = new ToolStripMenuItem();
        this.toolStripSeparator1 = new ToolStripSeparator();
        this.BtnCloseFile = new ToolStripMenuItem();
        this.toolStripSeparator2 = new ToolStripSeparator();
        this.BtnImportImages = new ToolStripMenuItem();
        this.BtnExportImages = new ToolStripMenuItem();
        this.toolStripSeparator3 = new ToolStripSeparator();
        this.BtnExit = new ToolStripMenuItem();
        this.EditMenu = new ToolStripMenuItem();
        this.BtnDeleteSelected = new ToolStripMenuItem();
        this.BtnCut = new ToolStripMenuItem();
        this.BtnCopy = new ToolStripMenuItem();
        this.BtnPaste = new ToolStripMenuItem();
        this.toolStripSeparator7 = new ToolStripSeparator();
        this.BtnSelectAll = new ToolStripMenuItem();
        this.toolsToolStripMenuItem = new ToolStripMenuItem();
        this.BtnListStyle = new ToolStripMenuItem();
        this.optionsToolStripMenuItem = new ToolStripMenuItem();
        this.BtnAutomaticBackups = new ToolStripMenuItem();
        this.helpToolStripMenuItem = new ToolStripMenuItem();
        this.BtnHelp = new ToolStripMenuItem();
        this.toolStripSeparator8 = new ToolStripSeparator();
        this.BtnAbout = new ToolStripMenuItem();
        this.toolStripContainer1 = new ToolStripContainer();
        this.toolStrip1 = new ToolStrip();
        this.BtnTsNew = new ToolStripButton();
        this.BtnTsOpen = new ToolStripButton();
        this.BtnTsSave = new ToolStripButton();
        this.BtnTsClose = new ToolStripButton();
        this.toolStripSeparator4 = new ToolStripSeparator();
        this.BtnTsDeleteSelected = new ToolStripButton();
        this.BtnTsCut = new ToolStripButton();
        this.BtnTsCopy = new ToolStripButton();
        this.BtnTsPaste = new ToolStripButton();
        this.toolStripSeparator5 = new ToolStripSeparator();
        this.BtnTsAbout = new ToolStripButton();
        this.menuStrip1.SuspendLayout();
        this.toolStripContainer1.ContentPanel.SuspendLayout();
        this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
        this.toolStripContainer1.SuspendLayout();
        this.toolStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // TcEditors
        // 
        this.TcEditors.Dock = DockStyle.Fill;
        this.TcEditors.Location = new Point(0, 0);
        this.TcEditors.Name = "TcEditors";
        this.TcEditors.SelectedIndex = 0;
        this.TcEditors.Size = new Size(1082, 806);
        this.TcEditors.TabIndex = 1;
        // 
        // menuStrip1
        // 
        this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.fileToolStripMenuItem1, this.EditMenu, this.toolsToolStripMenuItem, this.helpToolStripMenuItem });
        this.menuStrip1.Location = new Point(1, 5);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new Size(1082, 24);
        this.menuStrip1.TabIndex = 2;
        this.menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem1
        // 
        this.fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { this.BtnNew, this.BtnOpen, this.toolStripSeparator, this.BtnSave, this.BtnSaveAs, this.toolStripSeparator1, this.BtnCloseFile, this.toolStripSeparator2, this.BtnImportImages, this.BtnExportImages, this.toolStripSeparator3, this.BtnExit });
        this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
        this.fileToolStripMenuItem1.Size = new Size(37, 20);
        this.fileToolStripMenuItem1.Text = "&File";
        // 
        // BtnNew
        // 
        this.BtnNew.Image = (Image)resources.GetObject("BtnNew.Image");
        this.BtnNew.ImageTransparentColor = Color.Magenta;
        this.BtnNew.Name = "BtnNew";
        this.BtnNew.ShortcutKeys = Keys.Control | Keys.N;
        this.BtnNew.Size = new Size(180, 22);
        this.BtnNew.Text = "&New";
        this.BtnNew.Click += BtnNew_Click;
        // 
        // BtnOpen
        // 
        this.BtnOpen.Image = (Image)resources.GetObject("BtnOpen.Image");
        this.BtnOpen.ImageTransparentColor = Color.Magenta;
        this.BtnOpen.Name = "BtnOpen";
        this.BtnOpen.ShortcutKeys = Keys.Control | Keys.O;
        this.BtnOpen.Size = new Size(180, 22);
        this.BtnOpen.Text = "&Open";
        this.BtnOpen.Click += BtnOpen_Click;
        // 
        // toolStripSeparator
        // 
        this.toolStripSeparator.Name = "toolStripSeparator";
        this.toolStripSeparator.Size = new Size(177, 6);
        // 
        // BtnSave
        // 
        this.BtnSave.Image = (Image)resources.GetObject("BtnSave.Image");
        this.BtnSave.ImageTransparentColor = Color.Magenta;
        this.BtnSave.Name = "BtnSave";
        this.BtnSave.ShortcutKeys = Keys.Control | Keys.S;
        this.BtnSave.Size = new Size(180, 22);
        this.BtnSave.Text = "&Save";
        this.BtnSave.Click += BtnSave_Click;
        // 
        // BtnSaveAs
        // 
        this.BtnSaveAs.Name = "BtnSaveAs";
        this.BtnSaveAs.Size = new Size(180, 22);
        this.BtnSaveAs.Text = "Save &As";
        this.BtnSaveAs.Click += BtnSaveAs_Click;
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new Size(177, 6);
        // 
        // BtnCloseFile
        // 
        this.BtnCloseFile.Image = Properties.Resources.Close16;
        this.BtnCloseFile.Name = "BtnCloseFile";
        this.BtnCloseFile.Size = new Size(180, 22);
        this.BtnCloseFile.Text = "Close file";
        this.BtnCloseFile.Click += BtnClose_Click;
        // 
        // toolStripSeparator2
        // 
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new Size(177, 6);
        // 
        // BtnImportImages
        // 
        this.BtnImportImages.Name = "BtnImportImages";
        this.BtnImportImages.Size = new Size(180, 22);
        this.BtnImportImages.Text = "Import images...";
        this.BtnImportImages.Click += BtnImportImages_Click;
        // 
        // BtnExportImages
        // 
        this.BtnExportImages.Name = "BtnExportImages";
        this.BtnExportImages.Size = new Size(180, 22);
        this.BtnExportImages.Text = "Export images...";
        this.BtnExportImages.Click += BtnExportImages_Click;
        // 
        // toolStripSeparator3
        // 
        this.toolStripSeparator3.Name = "toolStripSeparator3";
        this.toolStripSeparator3.Size = new Size(177, 6);
        // 
        // BtnExit
        // 
        this.BtnExit.Name = "BtnExit";
        this.BtnExit.Size = new Size(180, 22);
        this.BtnExit.Text = "E&xit";
        this.BtnExit.Click += BtnExit_Click;
        // 
        // EditMenu
        // 
        this.EditMenu.DropDownItems.AddRange(new ToolStripItem[] { this.BtnDeleteSelected, this.BtnCut, this.BtnCopy, this.BtnPaste, this.toolStripSeparator7, this.BtnSelectAll });
        this.EditMenu.Name = "EditMenu";
        this.EditMenu.Size = new Size(39, 20);
        this.EditMenu.Text = "&Edit";
        // 
        // BtnDeleteSelected
        // 
        this.BtnDeleteSelected.Image = Properties.Resources.Delete16;
        this.BtnDeleteSelected.Name = "BtnDeleteSelected";
        this.BtnDeleteSelected.Size = new Size(158, 22);
        this.BtnDeleteSelected.Text = "Remove images";
        this.BtnDeleteSelected.Click += BtnDeleteSelected_Click;
        // 
        // BtnCut
        // 
        this.BtnCut.Image = (Image)resources.GetObject("BtnCut.Image");
        this.BtnCut.ImageTransparentColor = Color.Magenta;
        this.BtnCut.Name = "BtnCut";
        this.BtnCut.ShortcutKeys = Keys.Control | Keys.X;
        this.BtnCut.Size = new Size(158, 22);
        this.BtnCut.Text = "Cu&t";
        this.BtnCut.Click += BtnCut_Click;
        // 
        // BtnCopy
        // 
        this.BtnCopy.Image = (Image)resources.GetObject("BtnCopy.Image");
        this.BtnCopy.ImageTransparentColor = Color.Magenta;
        this.BtnCopy.Name = "BtnCopy";
        this.BtnCopy.ShortcutKeys = Keys.Control | Keys.C;
        this.BtnCopy.Size = new Size(158, 22);
        this.BtnCopy.Text = "&Copy";
        this.BtnCopy.Click += BtnCopy_Click;
        // 
        // BtnPaste
        // 
        this.BtnPaste.Image = (Image)resources.GetObject("BtnPaste.Image");
        this.BtnPaste.ImageTransparentColor = Color.Magenta;
        this.BtnPaste.Name = "BtnPaste";
        this.BtnPaste.ShortcutKeys = Keys.Control | Keys.V;
        this.BtnPaste.Size = new Size(158, 22);
        this.BtnPaste.Text = "&Paste";
        this.BtnPaste.Click += BtnPaste_Click;
        // 
        // toolStripSeparator7
        // 
        this.toolStripSeparator7.Name = "toolStripSeparator7";
        this.toolStripSeparator7.Size = new Size(155, 6);
        // 
        // BtnSelectAll
        // 
        this.BtnSelectAll.Name = "BtnSelectAll";
        this.BtnSelectAll.Size = new Size(158, 22);
        this.BtnSelectAll.Text = "Select &All";
        this.BtnSelectAll.Click += BtnSelectAll_Click;
        // 
        // toolsToolStripMenuItem
        // 
        this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.BtnListStyle, this.optionsToolStripMenuItem });
        this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
        this.toolsToolStripMenuItem.Size = new Size(46, 20);
        this.toolsToolStripMenuItem.Text = "&Tools";
        // 
        // BtnListStyle
        // 
        this.BtnListStyle.Name = "BtnListStyle";
        this.BtnListStyle.Size = new Size(120, 22);
        this.BtnListStyle.Text = "List Style";
        // 
        // optionsToolStripMenuItem
        // 
        this.optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.BtnAutomaticBackups });
        this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
        this.optionsToolStripMenuItem.Size = new Size(120, 22);
        this.optionsToolStripMenuItem.Text = "&Options";
        // 
        // BtnAutomaticBackups
        // 
        this.BtnAutomaticBackups.Name = "BtnAutomaticBackups";
        this.BtnAutomaticBackups.Size = new Size(212, 22);
        this.BtnAutomaticBackups.Text = "Create automatic backups";
        this.BtnAutomaticBackups.Click += BtnAutomaticBackups_Click;
        // 
        // helpToolStripMenuItem
        // 
        this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.BtnHelp, this.toolStripSeparator8, this.BtnAbout });
        this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        this.helpToolStripMenuItem.Size = new Size(44, 20);
        this.helpToolStripMenuItem.Text = "&Help";
        // 
        // BtnHelp
        // 
        this.BtnHelp.Name = "BtnHelp";
        this.BtnHelp.Size = new Size(122, 22);
        this.BtnHelp.Text = "&Contents";
        this.BtnHelp.Click += BtnHelp_Click;
        // 
        // toolStripSeparator8
        // 
        this.toolStripSeparator8.Name = "toolStripSeparator8";
        this.toolStripSeparator8.Size = new Size(119, 6);
        // 
        // BtnAbout
        // 
        this.BtnAbout.Name = "BtnAbout";
        this.BtnAbout.Size = new Size(122, 22);
        this.BtnAbout.Text = "&About...";
        this.BtnAbout.Click += BtnAbout_Click;
        // 
        // toolStripContainer1
        // 
        // 
        // toolStripContainer1.ContentPanel
        // 
        this.toolStripContainer1.ContentPanel.Controls.Add(this.TcEditors);
        this.toolStripContainer1.ContentPanel.Size = new Size(1082, 806);
        this.toolStripContainer1.Dock = DockStyle.Fill;
        this.toolStripContainer1.Location = new Point(1, 29);
        this.toolStripContainer1.Name = "toolStripContainer1";
        this.toolStripContainer1.Size = new Size(1082, 831);
        this.toolStripContainer1.TabIndex = 3;
        this.toolStripContainer1.Text = "toolStripContainer1";
        // 
        // toolStripContainer1.TopToolStripPanel
        // 
        this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
        // 
        // toolStrip1
        // 
        this.toolStrip1.Dock = DockStyle.None;
        this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.BtnTsNew, this.BtnTsOpen, this.BtnTsSave, this.BtnTsClose, this.toolStripSeparator4, this.BtnTsDeleteSelected, this.BtnTsCut, this.BtnTsCopy, this.BtnTsPaste, this.toolStripSeparator5, this.BtnTsAbout });
        this.toolStrip1.Location = new Point(3, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new Size(231, 25);
        this.toolStrip1.TabIndex = 0;
        // 
        // BtnTsNew
        // 
        this.BtnTsNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsNew.Image = (Image)resources.GetObject("BtnTsNew.Image");
        this.BtnTsNew.ImageTransparentColor = Color.Magenta;
        this.BtnTsNew.Name = "BtnTsNew";
        this.BtnTsNew.Size = new Size(23, 22);
        this.BtnTsNew.Text = "&New";
        this.BtnTsNew.Click += BtnNew_Click;
        // 
        // BtnTsOpen
        // 
        this.BtnTsOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsOpen.Image = (Image)resources.GetObject("BtnTsOpen.Image");
        this.BtnTsOpen.ImageTransparentColor = Color.Magenta;
        this.BtnTsOpen.Name = "BtnTsOpen";
        this.BtnTsOpen.Size = new Size(23, 22);
        this.BtnTsOpen.Text = "&Open";
        this.BtnTsOpen.Click += BtnOpen_Click;
        // 
        // BtnTsSave
        // 
        this.BtnTsSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsSave.Image = (Image)resources.GetObject("BtnTsSave.Image");
        this.BtnTsSave.ImageTransparentColor = Color.Magenta;
        this.BtnTsSave.Name = "BtnTsSave";
        this.BtnTsSave.Size = new Size(23, 22);
        this.BtnTsSave.Text = "&Save";
        this.BtnTsSave.Click += BtnSave_Click;
        // 
        // BtnTsClose
        // 
        this.BtnTsClose.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsClose.Image = Properties.Resources.Close16;
        this.BtnTsClose.ImageTransparentColor = Color.Magenta;
        this.BtnTsClose.Name = "BtnTsClose";
        this.BtnTsClose.Size = new Size(23, 22);
        this.BtnTsClose.Text = "Close File";
        this.BtnTsClose.Click += BtnClose_Click;
        // 
        // toolStripSeparator4
        // 
        this.toolStripSeparator4.Name = "toolStripSeparator4";
        this.toolStripSeparator4.Size = new Size(6, 25);
        // 
        // BtnTsDeleteSelected
        // 
        this.BtnTsDeleteSelected.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsDeleteSelected.Image = Properties.Resources.Delete16;
        this.BtnTsDeleteSelected.ImageTransparentColor = Color.Magenta;
        this.BtnTsDeleteSelected.Name = "BtnTsDeleteSelected";
        this.BtnTsDeleteSelected.Size = new Size(23, 22);
        this.BtnTsDeleteSelected.Text = "Delete Selected";
        this.BtnTsDeleteSelected.Click += BtnDeleteSelected_Click;
        // 
        // BtnTsCut
        // 
        this.BtnTsCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsCut.Image = (Image)resources.GetObject("BtnTsCut.Image");
        this.BtnTsCut.ImageTransparentColor = Color.Magenta;
        this.BtnTsCut.Name = "BtnTsCut";
        this.BtnTsCut.Size = new Size(23, 22);
        this.BtnTsCut.Text = "C&ut";
        this.BtnTsCut.Click += BtnCut_Click;
        // 
        // BtnTsCopy
        // 
        this.BtnTsCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsCopy.Image = (Image)resources.GetObject("BtnTsCopy.Image");
        this.BtnTsCopy.ImageTransparentColor = Color.Magenta;
        this.BtnTsCopy.Name = "BtnTsCopy";
        this.BtnTsCopy.Size = new Size(23, 22);
        this.BtnTsCopy.Text = "&Copy";
        this.BtnTsCopy.Click += BtnCopy_Click;
        // 
        // BtnTsPaste
        // 
        this.BtnTsPaste.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsPaste.Image = (Image)resources.GetObject("BtnTsPaste.Image");
        this.BtnTsPaste.ImageTransparentColor = Color.Magenta;
        this.BtnTsPaste.Name = "BtnTsPaste";
        this.BtnTsPaste.Size = new Size(23, 22);
        this.BtnTsPaste.Text = "&Paste";
        this.BtnTsPaste.Click += BtnPaste_Click;
        // 
        // toolStripSeparator5
        // 
        this.toolStripSeparator5.Name = "toolStripSeparator5";
        this.toolStripSeparator5.Size = new Size(6, 25);
        // 
        // BtnTsAbout
        // 
        this.BtnTsAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
        this.BtnTsAbout.Image = (Image)resources.GetObject("BtnTsAbout.Image");
        this.BtnTsAbout.ImageTransparentColor = Color.Magenta;
        this.BtnTsAbout.Name = "BtnTsAbout";
        this.BtnTsAbout.Size = new Size(23, 22);
        this.BtnTsAbout.Text = "He&lp";
        this.BtnTsAbout.Click += BtnAbout_Click;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1084, 861);
        Controls.Add(this.toolStripContainer1);
        Controls.Add(this.menuStrip1);
        MainMenuStrip = this.menuStrip1;
        Name = "FrmMain";
        Padding = new Padding(1, 5, 1, 1);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "AO GUI Graphics Browser";
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.toolStripContainer1.ContentPanel.ResumeLayout(false);
        this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
        this.toolStripContainer1.TopToolStripPanel.PerformLayout();
        this.toolStripContainer1.ResumeLayout(false);
        this.toolStripContainer1.PerformLayout();
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private TabControl TcEditors;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem1;
    private ToolStripMenuItem BtnNew;
    private ToolStripMenuItem BtnOpen;
    private ToolStripSeparator toolStripSeparator;
    private ToolStripMenuItem BtnSave;
    private ToolStripMenuItem BtnSaveAs;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem BtnExit;
    private ToolStripMenuItem EditMenu;
    private ToolStripMenuItem BtnCut;
    private ToolStripMenuItem BtnCopy;
    private ToolStripMenuItem BtnPaste;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripMenuItem BtnSelectAll;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem BtnListStyle;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem BtnHelp;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripMenuItem BtnAbout;
    private ToolStripMenuItem BtnImportImages;
    private ToolStripMenuItem BtnExportImages;
    private ToolStripMenuItem BtnDeleteSelected;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem BtnCloseFile;
    private ToolStripContainer toolStripContainer1;
    private ToolStrip toolStrip1;
    private ToolStripButton BtnTsNew;
    private ToolStripButton BtnTsOpen;
    private ToolStripButton BtnTsSave;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton BtnTsCut;
    private ToolStripButton BtnTsCopy;
    private ToolStripButton BtnTsPaste;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripButton BtnTsAbout;
    private ToolStripButton BtnTsDeleteSelected;
    private ToolStripButton BtnTsClose;
    private ToolStripMenuItem BtnAutomaticBackups;
}
