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
        this.uvgaFileExplorer1 = new UvgaFileExplorer();
        SuspendLayout();
        // 
        // uvgaFileExplorer1
        // 
        this.uvgaFileExplorer1.Dock = DockStyle.Fill;
        this.uvgaFileExplorer1.Location = new Point(0, 0);
        this.uvgaFileExplorer1.Name = "uvgaFileExplorer1";
        this.uvgaFileExplorer1.Size = new Size(1084, 861);
        this.uvgaFileExplorer1.TabIndex = 0;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1084, 861);
        Controls.Add(this.uvgaFileExplorer1);
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "AO GUI Graphics Browser";
        ResumeLayout(false);
    }

    #endregion

    private UvgaFileExplorer uvgaFileExplorer1;
}
