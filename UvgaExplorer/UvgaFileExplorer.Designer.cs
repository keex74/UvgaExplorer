namespace UvgaExplorer
{
    partial class UvgaFileExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UvgaFileExplorer));
            this.bgwEditItem1 = new BgwEditItem();
            this.detailView1 = new DetailView();
            this.splitContainer1 = new SplitContainer();
            this.uvgaListDisplay1 = new UvgaListDisplay();
            ((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // detailView1
            // 
            this.detailView1.Dock = DockStyle.Fill;
            this.detailView1.Location = new Point(0, 0);
            this.detailView1.Name = "detailView1";
            this.detailView1.Size = new Size(179, 516);
            this.detailView1.TabIndex = 0;
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
            this.splitContainer1.Size = new Size(628, 516);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 1;
            // 
            // uvgaListDisplay1
            // 
            this.uvgaListDisplay1.ActiveImage = null;
            this.uvgaListDisplay1.Dock = DockStyle.Fill;
            this.uvgaListDisplay1.Liststyle = View.LargeIcon;
            this.uvgaListDisplay1.Location = new Point(0, 0);
            this.uvgaListDisplay1.Name = "uvgaListDisplay1";
            this.uvgaListDisplay1.Padding = new Padding(3);
            this.uvgaListDisplay1.Size = new Size(445, 516);
            this.uvgaListDisplay1.TabIndex = 0;
            // 
            // UvgaFileExplorer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(this.splitContainer1);
            Name = "UvgaFileExplorer";
            Size = new Size(628, 516);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private BgwEditItem bgwEditItem1;
        private DetailView detailView1;
        private SplitContainer splitContainer1;
        private UvgaListDisplay uvgaListDisplay1;
    }
}
