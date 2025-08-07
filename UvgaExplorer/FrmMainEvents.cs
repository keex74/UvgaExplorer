// <copyright file="FrmMainEvents.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.ComponentModel;

/// <summary>
/// Defines control event handlers for the main form.
/// </summary>
internal partial class FrmMain
{
    private void BgwEditItem_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        var res = e.Result as EditItemWorkerData;
        this.FinishItemEdit(res);
    }

    private void ListView1_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        var ht = this.listView1.HitTest(e.Location);
        if (ht.Item is DisplayWrapper dw)
        {
            var item = dw.SourceItem;
            this.EditFile(item);
        }
    }

    private void ListView1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        this.ShowSelectionDetails();
    }

    private void OpenToolStripButton_Click(object sender, EventArgs e)
    {
        this.OpenFile();
    }

    private void SaveToolStripButton_Click(object sender, EventArgs e)
    {
        this.SaveFileAs();
    }

    private void NewToolStripButton_Click(object sender, EventArgs e)
    {
        this.CreateNewFile();
    }

    private void CopyToolStripButton_Click(object sender, EventArgs e)
    {
        this.ExportSelectedImages();
    }

    private void BtnDeleteSelected_Click(object sender, EventArgs e)
    {
        this.DeleteSelected();
    }

    private void PasteToolStripButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "PNG Files|*.png";
        ofd.Multiselect = true;
        if (ofd.ShowDialog(this) == DialogResult.Cancel)
        {
            return;
        }

        this.ImportFiles(ofd.FileNames);
    }

    private void ListView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            foreach (ListViewItem i in this.listView1.Items)
            {
                i.Selected = true;
            }

            this.listView1.Refresh();
        }
    }

    private void BtnAbout_Click(object sender, EventArgs e)
    {
        using var frm = new FrmAbout();
        frm.ShowDialog(this);
    }
}
