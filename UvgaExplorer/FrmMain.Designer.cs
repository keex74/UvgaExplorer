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
        this.toolStripSeparator2 = new ToolStripSeparator();
        this.BtnImportImages = new ToolStripMenuItem();
        this.BtnExportImages = new ToolStripMenuItem();
        this.toolStripSeparator3 = new ToolStripSeparator();
        this.BtnClose = new ToolStripMenuItem();
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
        this.helpToolStripMenuItem = new ToolStripMenuItem();
        this.BtnHelp = new ToolStripMenuItem();
        this.toolStripSeparator8 = new ToolStripSeparator();
        this.BtnAbout = new ToolStripMenuItem();
        this.BtnCloseFile = new ToolStripMenuItem();
        this.toolStripSeparator1 = new ToolStripSeparator();
        this.menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // TcEditors
        // 
        this.TcEditors.Dock = DockStyle.Fill;
        this.TcEditors.Location = new Point(1, 29);
        this.TcEditors.Name = "TcEditors";
        this.TcEditors.SelectedIndex = 0;
        this.TcEditors.Size = new Size(1082, 831);
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
        this.fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { this.BtnNew, this.BtnOpen, this.toolStripSeparator, this.BtnSave, this.BtnSaveAs, this.toolStripSeparator1, this.BtnCloseFile, this.toolStripSeparator2, this.BtnImportImages, this.BtnExportImages, this.toolStripSeparator3, this.BtnClose });
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
        // 
        // BtnExportImages
        // 
        this.BtnExportImages.Name = "BtnExportImages";
        this.BtnExportImages.Size = new Size(180, 22);
        this.BtnExportImages.Text = "Export images...";
        // 
        // toolStripSeparator3
        // 
        this.toolStripSeparator3.Name = "toolStripSeparator3";
        this.toolStripSeparator3.Size = new Size(177, 6);
        // 
        // BtnClose
        // 
        this.BtnClose.Name = "BtnClose";
        this.BtnClose.Size = new Size(180, 22);
        this.BtnClose.Text = "E&xit";
        this.BtnClose.Click += BtnClose_Click;
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
        this.BtnDeleteSelected.Name = "BtnDeleteSelected";
        this.BtnDeleteSelected.Size = new Size(180, 22);
        this.BtnDeleteSelected.Text = "Remove images";
        this.BtnDeleteSelected.Click += BtnDeleteSelected_Click;
        // 
        // BtnCut
        // 
        this.BtnCut.Image = (Image)resources.GetObject("BtnCut.Image");
        this.BtnCut.ImageTransparentColor = Color.Magenta;
        this.BtnCut.Name = "BtnCut";
        this.BtnCut.ShortcutKeys = Keys.Control | Keys.X;
        this.BtnCut.Size = new Size(180, 22);
        this.BtnCut.Text = "Cu&t";
        this.BtnCut.Click += BtnCut_Click;
        // 
        // BtnCopy
        // 
        this.BtnCopy.Image = (Image)resources.GetObject("BtnCopy.Image");
        this.BtnCopy.ImageTransparentColor = Color.Magenta;
        this.BtnCopy.Name = "BtnCopy";
        this.BtnCopy.ShortcutKeys = Keys.Control | Keys.C;
        this.BtnCopy.Size = new Size(180, 22);
        this.BtnCopy.Text = "&Copy";
        this.BtnCopy.Click += BtnCopy_Click;
        // 
        // BtnPaste
        // 
        this.BtnPaste.Image = (Image)resources.GetObject("BtnPaste.Image");
        this.BtnPaste.ImageTransparentColor = Color.Magenta;
        this.BtnPaste.Name = "BtnPaste";
        this.BtnPaste.ShortcutKeys = Keys.Control | Keys.V;
        this.BtnPaste.Size = new Size(180, 22);
        this.BtnPaste.Text = "&Paste";
        this.BtnPaste.Click += BtnPaste_Click;
        // 
        // toolStripSeparator7
        // 
        this.toolStripSeparator7.Name = "toolStripSeparator7";
        this.toolStripSeparator7.Size = new Size(177, 6);
        // 
        // BtnSelectAll
        // 
        this.BtnSelectAll.Name = "BtnSelectAll";
        this.BtnSelectAll.Size = new Size(180, 22);
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
        this.optionsToolStripMenuItem.Enabled = false;
        this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
        this.optionsToolStripMenuItem.Size = new Size(120, 22);
        this.optionsToolStripMenuItem.Text = "&Options";
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
        // BtnCloseFile
        // 
        this.BtnCloseFile.Name = "BtnCloseFile";
        this.BtnCloseFile.Size = new Size(180, 22);
        this.BtnCloseFile.Text = "Close file";
        this.BtnCloseFile.Click += BtnClose_Click;
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new Size(177, 6);
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1084, 861);
        Controls.Add(this.TcEditors);
        Controls.Add(this.menuStrip1);
        MainMenuStrip = this.menuStrip1;
        Name = "FrmMain";
        Padding = new Padding(1, 5, 1, 1);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "AO GUI Graphics Browser";
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
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
    private ToolStripMenuItem BtnClose;
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
}
