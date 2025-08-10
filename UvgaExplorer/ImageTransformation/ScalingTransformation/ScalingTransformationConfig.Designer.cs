namespace UvgaExplorer.ImageTransformation.ScalingTransformation
{
    partial class ScalingTransformationConfig
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
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.NumScale = new NumericUpDown();
            this.label2 = new Label();
            this.LblResultSize = new Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.NumScale).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NumScale, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblResultSize, 1, 1);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new Size(266, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(16, 7);
            this.label1.Margin = new Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scaling Factor [%]:";
            // 
            // NumScale
            // 
            this.NumScale.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.NumScale.Location = new Point(127, 3);
            this.NumScale.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.NumScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.NumScale.Name = "NumScale";
            this.NumScale.Size = new Size(136, 23);
            this.NumScale.TabIndex = 1;
            this.NumScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label2
            // 
            this.label2.Anchor = AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 32);
            this.label2.Margin = new Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new Size(118, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Example for 150x100:";
            // 
            // LblResultSize
            // 
            this.LblResultSize.AutoSize = true;
            this.LblResultSize.Location = new Point(127, 32);
            this.LblResultSize.Margin = new Padding(3);
            this.LblResultSize.Name = "LblResultSize";
            this.LblResultSize.Size = new Size(25, 15);
            this.LblResultSize.TabIndex = 3;
            this.LblResultSize.Text = "1x1";
            // 
            // ScalingTransformationConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(this.tableLayoutPanel1);
            Name = "ScalingTransformationConfig";
            Size = new Size(266, 78);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.NumScale).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private NumericUpDown NumScale;
        private Label label2;
        private Label LblResultSize;
    }
}
