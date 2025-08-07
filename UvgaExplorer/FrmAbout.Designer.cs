namespace UvgaExplorer
{
    partial class FrmAbout
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
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.button1 = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new Size(286, 290);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(3, 135);
            this.label3.Margin = new Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(279, 90);
            this.label3.TabIndex = 2;
            this.label3.Text = "All code and compiled binaries are released into the Public Domain under Creative Commons CC0.\r\nHave fun!\r\n\r\nBest regards\r\nKeex";
            this.label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(8, 65);
            this.label2.Margin = new Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(269, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = "The associated library LibUvgaFile implements reading and writing of the files with a straightforward API.\r\nIt is writted as a portable .NET Standard 2.0 library.";
            this.label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 10);
            this.label1.Margin = new Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(269, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "This tool is intended to allow easy editing of the UVGA/UVGI files that contain graphics for custom UIs for the game Anarchy Online.";
            this.label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Anchor = AnchorStyles.Bottom;
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(105, 250);
            this.button1.Margin = new Padding(3, 3, 3, 15);
            this.button1.Name = "button1";
            this.button1.Padding = new Padding(20, 0, 20, 0);
            this.button1.Size = new Size(75, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Oki";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmAbout
            // 
            AcceptButton = this.button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 290);
            Controls.Add(this.tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button button1;
    }
}