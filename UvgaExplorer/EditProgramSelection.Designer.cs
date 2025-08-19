namespace UvgaExplorer
{
    partial class EditProgramSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProgramSelection));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.TbProgramPath = new TextBox();
            this.BtnSearchFile = new Button();
            this.label3 = new Label();
            this.TbArguments = new TextBox();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.BtnOK = new Button();
            this.BtnCancel = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TbProgramPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnSearchFile, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TbArguments, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.Size = new Size(376, 228);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Location = new Point(3, 0);
            this.label1.Margin = new Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(368, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.Anchor = AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 93);
            this.label2.Name = "label2";
            this.label2.Size = new Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Program:";
            // 
            // TbProgramPath
            // 
            this.TbProgramPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.TbProgramPath.Location = new Point(78, 89);
            this.TbProgramPath.Name = "TbProgramPath";
            this.TbProgramPath.Size = new Size(263, 23);
            this.TbProgramPath.TabIndex = 2;
            // 
            // BtnSearchFile
            // 
            this.BtnSearchFile.Anchor = AnchorStyles.Left;
            this.BtnSearchFile.AutoSize = true;
            this.BtnSearchFile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnSearchFile.Location = new Point(347, 88);
            this.BtnSearchFile.Name = "BtnSearchFile";
            this.BtnSearchFile.Size = new Size(26, 25);
            this.BtnSearchFile.TabIndex = 3;
            this.BtnSearchFile.Text = "...";
            this.BtnSearchFile.UseVisualStyleBackColor = true;
            this.BtnSearchFile.Click += BtnSearchFile_Click;
            // 
            // label3
            // 
            this.label3.Anchor = AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(3, 123);
            this.label3.Name = "label3";
            this.label3.Size = new Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Arguments:";
            // 
            // TbArguments
            // 
            this.TbArguments.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.TbArguments.Location = new Point(78, 119);
            this.TbArguments.Name = "TbArguments";
            this.TbArguments.Size = new Size(263, 23);
            this.TbArguments.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BtnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 1, 0);
            this.tableLayoutPanel2.Location = new Point(3, 188);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new Size(370, 37);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = AnchorStyles.Right;
            this.BtnOK.AutoSize = true;
            this.BtnOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnOK.Location = new Point(99, 3);
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
            this.BtnCancel.Anchor = AnchorStyles.Left;
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnCancel.Location = new Point(188, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Padding = new Padding(13, 3, 13, 3);
            this.BtnCancel.Size = new Size(79, 31);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += BtnCancel_Click;
            // 
            // EditProgramSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 258);
            Controls.Add(this.tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "EditProgramSelection";
            Padding = new Padding(15);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Define editing program";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TextBox TbProgramPath;
        private Button BtnSearchFile;
        private Label label3;
        private TextBox TbArguments;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnOK;
        private Button BtnCancel;
    }
}