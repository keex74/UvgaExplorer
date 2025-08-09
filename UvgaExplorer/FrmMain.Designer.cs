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
        this.toolStripContainer1 = new ToolStripContainer();
        this.splitContainer1 = new SplitContainer();
        this.uvgaListDisplay1 = new UvgaListDisplay();
        this.detailView1 = new DetailView();
        this.toolStrip1 = new ToolStrip();
        this.BtnNewUvga = new ToolStripButton();
        this.BtnOpenUVGA = new ToolStripButton();
        this.BtnSaveAs = new ToolStripButton();
        this.toolStripSeparator = new ToolStripSeparator();
        this.BtnDeleteSelected = new ToolStripButton();
        this.BtnExportSelected = new ToolStripButton();
        this.BtnImportImages = new ToolStripButton();
        this.toolStripSeparator1 = new ToolStripSeparator();
        this.BtnAbout = new ToolStripButton();
        this.bgwEditItem1 = new BgwEditItem();
        this.toolStripSeparator2 = new ToolStripSeparator();
        this.BtnListStyle = new ToolStripDropDownButton();
        this.toolStripContainer1.ContentPanel.SuspendLayout();
        this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
        this.toolStripContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
        this.splitContainer1.Panel1.SuspendLayout();
        this.splitContainer1.Panel2.SuspendLayout();
        this.splitContainer1.SuspendLayout();
        this.toolStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // toolStripContainer1
        // 
        this.toolStripContainer1.BottomToolStripPanelVisible = false;
        // 
        // toolStripContainer1.ContentPanel
        // 
        this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
        this.toolStripContainer1.ContentPanel.Size = new Size(1084, 836);
        this.toolStripContainer1.Dock = DockStyle.Fill;
        this.toolStripContainer1.LeftToolStripPanelVisible = false;
        this.toolStripContainer1.Location = new Point(0, 0);
        this.toolStripContainer1.Name = "toolStripContainer1";
        this.toolStripContainer1.RightToolStripPanelVisible = false;
        this.toolStripContainer1.Size = new Size(1084, 861);
        this.toolStripContainer1.TabIndex = 0;
        this.toolStripContainer1.Text = "toolStripContainer1";
        // 
        // toolStripContainer1.TopToolStripPanel
        // 
        this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
        // 
        // splitContainer1
        // 
        this.splitContainer1.Dock = DockStyle.Fill;
        this.splitContainer1.Location = new Point(0, 0);
        this.splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        this.splitContainer1.Panel1.Controls.Add(this.uvgaListDisplay1);
        // 
        // splitContainer1.Panel2
        // 
        this.splitContainer1.Panel2.Controls.Add(this.detailView1);
        this.splitContainer1.Size = new Size(1084, 836);
        this.splitContainer1.SplitterDistance = 769;
        this.splitContainer1.TabIndex = 1;
        // 
        // uvgaListDisplay1
        // 
        this.uvgaListDisplay1.ActiveImage = null;
        this.uvgaListDisplay1.Dock = DockStyle.Fill;
        this.uvgaListDisplay1.Location = new Point(0, 0);
        this.uvgaListDisplay1.Name = "uvgaListDisplay1";
        this.uvgaListDisplay1.Size = new Size(769, 836);
        this.uvgaListDisplay1.TabIndex = 0;
        // 
        // detailView1
        // 
        this.detailView1.Dock = DockStyle.Fill;
        this.detailView1.Location = new Point(0, 0);
        this.detailView1.Name = "detailView1";
        this.detailView1.Size = new Size(311, 836);
        this.detailView1.TabIndex = 0;
        // 
        // toolStrip1
        // 
        this.toolStrip1.Dock = DockStyle.None;
        this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.BtnNewUvga, this.BtnOpenUVGA, this.BtnSaveAs, this.toolStripSeparator, this.BtnDeleteSelected, this.BtnExportSelected, this.BtnImportImages, this.toolStripSeparator1, this.BtnAbout, this.toolStripSeparator2, this.BtnListStyle });
        this.toolStrip1.Location = new Point(3, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new Size(678, 25);
        this.toolStrip1.TabIndex = 0;
        // 
        // BtnNewUvga
        // 
        this.BtnNewUvga.Image = (Image)resources.GetObject("BtnNewUvga.Image");
        this.BtnNewUvga.ImageTransparentColor = Color.Magenta;
        this.BtnNewUvga.Name = "BtnNewUvga";
        this.BtnNewUvga.Size = new Size(51, 22);
        this.BtnNewUvga.Text = "&New";
        this.BtnNewUvga.Click += NewToolStripButton_Click;
        // 
        // BtnOpenUVGA
        // 
        this.BtnOpenUVGA.Image = (Image)resources.GetObject("BtnOpenUVGA.Image");
        this.BtnOpenUVGA.ImageTransparentColor = Color.Magenta;
        this.BtnOpenUVGA.Name = "BtnOpenUVGA";
        this.BtnOpenUVGA.Size = new Size(56, 22);
        this.BtnOpenUVGA.Text = "&Open";
        this.BtnOpenUVGA.Click += OpenToolStripButton_Click;
        // 
        // BtnSaveAs
        // 
        this.BtnSaveAs.Image = (Image)resources.GetObject("BtnSaveAs.Image");
        this.BtnSaveAs.ImageTransparentColor = Color.Magenta;
        this.BtnSaveAs.Name = "BtnSaveAs";
        this.BtnSaveAs.Size = new Size(67, 22);
        this.BtnSaveAs.Text = "&Save As";
        this.BtnSaveAs.Click += SaveToolStripButton_Click;
        // 
        // toolStripSeparator
        // 
        this.toolStripSeparator.Name = "toolStripSeparator";
        this.toolStripSeparator.Size = new Size(6, 25);
        // 
        // BtnDeleteSelected
        // 
        this.BtnDeleteSelected.Image = (Image)resources.GetObject("BtnDeleteSelected.Image");
        this.BtnDeleteSelected.ImageTransparentColor = Color.Magenta;
        this.BtnDeleteSelected.Name = "BtnDeleteSelected";
        this.BtnDeleteSelected.Size = new Size(106, 22);
        this.BtnDeleteSelected.Text = "Delete selected";
        this.BtnDeleteSelected.Click += BtnDeleteSelected_Click;
        // 
        // BtnExportSelected
        // 
        this.BtnExportSelected.Image = (Image)resources.GetObject("BtnExportSelected.Image");
        this.BtnExportSelected.ImageTransparentColor = Color.Magenta;
        this.BtnExportSelected.Name = "BtnExportSelected";
        this.BtnExportSelected.Size = new Size(107, 22);
        this.BtnExportSelected.Text = "Export selected";
        this.BtnExportSelected.Click += CopyToolStripButton_Click;
        // 
        // BtnImportImages
        // 
        this.BtnImportImages.Image = (Image)resources.GetObject("BtnImportImages.Image");
        this.BtnImportImages.ImageTransparentColor = Color.Magenta;
        this.BtnImportImages.Name = "BtnImportImages";
        this.BtnImportImages.Size = new Size(104, 22);
        this.BtnImportImages.Text = "Import images";
        this.BtnImportImages.Click += PasteToolStripButton_Click;
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new Size(6, 25);
        // 
        // BtnAbout
        // 
        this.BtnAbout.Image = (Image)resources.GetObject("BtnAbout.Image");
        this.BtnAbout.ImageTransparentColor = Color.Magenta;
        this.BtnAbout.Name = "BtnAbout";
        this.BtnAbout.Size = new Size(60, 22);
        this.BtnAbout.Text = "About";
        this.BtnAbout.Click += BtnAbout_Click;
        // 
        // toolStripSeparator2
        // 
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new Size(6, 25);
        // 
        // BtnListStyle
        // 
        this.BtnListStyle.DisplayStyle = ToolStripItemDisplayStyle.Text;
        this.BtnListStyle.Image = (Image)resources.GetObject("BtnListStyle.Image");
        this.BtnListStyle.ImageTransparentColor = Color.Magenta;
        this.BtnListStyle.Name = "BtnListStyle";
        this.BtnListStyle.Size = new Size(66, 22);
        this.BtnListStyle.Text = "List Style";
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1084, 861);
        Controls.Add(this.toolStripContainer1);
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "AO GUI Graphics Browser";
        this.toolStripContainer1.ContentPanel.ResumeLayout(false);
        this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
        this.toolStripContainer1.TopToolStripPanel.PerformLayout();
        this.toolStripContainer1.ResumeLayout(false);
        this.toolStripContainer1.PerformLayout();
        this.splitContainer1.Panel1.ResumeLayout(false);
        this.splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
        this.splitContainer1.ResumeLayout(false);
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ToolStripContainer toolStripContainer1;
    private ToolStrip toolStrip1;
    private ToolStripButton BtnNewUvga;
    private ToolStripButton BtnOpenUVGA;
    private ToolStripButton BtnSaveAs;
    private ToolStripSeparator toolStripSeparator;
    private ToolStripButton BtnExportSelected;
    private ToolStripButton BtnImportImages;
    private ToolStripSeparator toolStripSeparator1;
    private SplitContainer splitContainer1;
    private DetailView detailView1;
    private ToolStripButton BtnDeleteSelected;
    private BgwEditItem bgwEditItem1;
    private ToolStripButton BtnAbout;
    private UvgaListDisplay uvgaListDisplay1;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripDropDownButton BtnListStyle;
}
