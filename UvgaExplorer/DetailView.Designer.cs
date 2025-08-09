namespace UvgaExplorer;

partial class DetailView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.splitContainer2 = new SplitContainer();
        this.panel1 = new Panel();
        this.pictureBox1 = new PictureBox();
        this.tableLayoutPanel1 = new TableLayoutPanel();
        this.TbImageFormat = new TextBox();
        this.TbImageSize = new TextBox();
        this.label1 = new Label();
        this.TbFilename = new TextBox();
        this.label2 = new Label();
        this.label3 = new Label();
        this.BtnSaveImage = new Button();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer2).BeginInit();
        this.splitContainer2.Panel1.SuspendLayout();
        this.splitContainer2.Panel2.SuspendLayout();
        this.splitContainer2.SuspendLayout();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        this.tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer2
        // 
        this.splitContainer2.Dock = DockStyle.Fill;
        this.splitContainer2.Location = new Point(0, 0);
        this.splitContainer2.Name = "splitContainer2";
        this.splitContainer2.Orientation = Orientation.Horizontal;
        // 
        // splitContainer2.Panel1
        // 
        this.splitContainer2.Panel1.Controls.Add(this.panel1);
        this.splitContainer2.Panel1.Padding = new Padding(3);
        // 
        // splitContainer2.Panel2
        // 
        this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
        this.splitContainer2.Size = new Size(268, 386);
        this.splitContainer2.SplitterDistance = 134;
        this.splitContainer2.TabIndex = 1;
        // 
        // panel1
        // 
        this.panel1.AutoScroll = true;
        this.panel1.BorderStyle = BorderStyle.FixedSingle;
        this.panel1.Controls.Add(this.pictureBox1);
        this.panel1.Dock = DockStyle.Fill;
        this.panel1.Location = new Point(3, 3);
        this.panel1.Name = "panel1";
        this.panel1.Size = new Size(262, 128);
        this.panel1.TabIndex = 1;
        // 
        // pictureBox1
        // 
        this.pictureBox1.Location = new Point(0, 0);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new Size(2, 1);
        this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        this.pictureBox1.TabIndex = 0;
        this.pictureBox1.TabStop = false;
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 2;
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.Controls.Add(this.TbImageFormat, 1, 2);
        this.tableLayoutPanel1.Controls.Add(this.TbImageSize, 1, 1);
        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.TbFilename, 1, 0);
        this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.BtnSaveImage, 1, 3);
        this.tableLayoutPanel1.Dock = DockStyle.Fill;
        this.tableLayoutPanel1.Location = new Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 4;
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.Size = new Size(268, 248);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // TbImageFormat
        // 
        this.TbImageFormat.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        this.TbImageFormat.Location = new Point(91, 61);
        this.TbImageFormat.Name = "TbImageFormat";
        this.TbImageFormat.ReadOnly = true;
        this.TbImageFormat.Size = new Size(174, 23);
        this.TbImageFormat.TabIndex = 5;
        // 
        // TbImageSize
        // 
        this.TbImageSize.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        this.TbImageSize.Location = new Point(91, 32);
        this.TbImageSize.Name = "TbImageSize";
        this.TbImageSize.ReadOnly = true;
        this.TbImageSize.Size = new Size(174, 23);
        this.TbImageSize.TabIndex = 4;
        // 
        // label1
        // 
        this.label1.Anchor = AnchorStyles.Right;
        this.label1.AutoSize = true;
        this.label1.Location = new Point(27, 7);
        this.label1.Name = "label1";
        this.label1.Size = new Size(58, 15);
        this.label1.TabIndex = 0;
        this.label1.Text = "Filename:";
        // 
        // TbFilename
        // 
        this.TbFilename.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        this.TbFilename.Location = new Point(91, 3);
        this.TbFilename.Name = "TbFilename";
        this.TbFilename.ReadOnly = true;
        this.TbFilename.Size = new Size(174, 23);
        this.TbFilename.TabIndex = 1;
        // 
        // label2
        // 
        this.label2.Anchor = AnchorStyles.Right;
        this.label2.AutoSize = true;
        this.label2.Location = new Point(20, 36);
        this.label2.Name = "label2";
        this.label2.Size = new Size(65, 15);
        this.label2.TabIndex = 2;
        this.label2.Text = "Image size:";
        // 
        // label3
        // 
        this.label3.Anchor = AnchorStyles.Right;
        this.label3.AutoSize = true;
        this.label3.Location = new Point(3, 65);
        this.label3.Name = "label3";
        this.label3.Size = new Size(82, 15);
        this.label3.TabIndex = 3;
        this.label3.Text = "Image format:";
        // 
        // BtnSaveImage
        // 
        this.BtnSaveImage.AutoSize = true;
        this.BtnSaveImage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        this.BtnSaveImage.Location = new Point(91, 90);
        this.BtnSaveImage.Name = "BtnSaveImage";
        this.BtnSaveImage.Size = new Size(100, 25);
        this.BtnSaveImage.TabIndex = 6;
        this.BtnSaveImage.Text = "Save image as...";
        this.BtnSaveImage.UseVisualStyleBackColor = true;
        this.BtnSaveImage.Click += BtnSaveImage_Click;
        // 
        // DetailView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(this.splitContainer2);
        Name = "DetailView";
        Size = new Size(268, 386);
        this.splitContainer2.Panel1.ResumeLayout(false);
        this.splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.splitContainer2).EndInit();
        this.splitContainer2.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer2;
    private PictureBox pictureBox1;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private TextBox TbFilename;
    private TextBox TbImageFormat;
    private TextBox TbImageSize;
    private Label label2;
    private Label label3;
    private Button BtnSaveImage;
    private Panel panel1;
}
