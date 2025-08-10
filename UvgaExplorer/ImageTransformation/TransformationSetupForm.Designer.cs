namespace UvgaExplorer.ImageTransformation
{
    partial class TransformationSetupForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.BtnOK = new Button();
            this.BtnCancel = new Button();
            this.panel1 = new Panel();
            this.tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BtnOK, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnCancel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.Size = new Size(414, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.BtnOK.AutoSize = true;
            this.BtnOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnOK.Location = new Point(121, 266);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Padding = new Padding(25, 3, 25, 3);
            this.BtnOK.Size = new Size(83, 31);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += BtnOK_Click;
            // 
            // BtnCancel
            // 
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnCancel.Location = new Point(210, 266);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Padding = new Padding(15, 3, 15, 3);
            this.BtnCancel.Size = new Size(83, 31);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += BtnCancel_Click;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(408, 257);
            this.panel1.TabIndex = 2;
            // 
            // TransformationSetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 300);
            Controls.Add(this.tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "TransformationSetupForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transformation Setup";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button BtnOK;
        private Button BtnCancel;
        private Panel panel1;
    }
}