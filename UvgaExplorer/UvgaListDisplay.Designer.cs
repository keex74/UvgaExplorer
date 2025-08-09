namespace UvgaExplorer
{
    partial class UvgaListDisplay
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
            this.LvImages = new DblBufferedListView();
            this.statusStrip1 = new StatusStrip();
            this.LblImageCount = new ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dblBufferedListView1
            // 
            this.LvImages.Dock = DockStyle.Fill;
            this.LvImages.Location = new Point(0, 0);
            this.LvImages.Name = "dblBufferedListView1";
            this.LvImages.Size = new Size(626, 354);
            this.LvImages.TabIndex = 0;
            this.LvImages.UseCompatibleStateImageBehavior = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new ToolStripItem[] { this.LblImageCount });
            this.statusStrip1.Location = new Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(626, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblImageCount
            // 
            this.LblImageCount.Name = "LblImageCount";
            this.LblImageCount.Size = new Size(54, 17);
            this.LblImageCount.Text = "0 images";
            // 
            // UvgaListDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(this.LvImages);
            Controls.Add(this.statusStrip1);
            Name = "UvgaListDisplay";
            Size = new Size(626, 376);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DblBufferedListView LvImages;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LblImageCount;
    }
}
