// <copyright file="BgwEditItem.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using System.ComponentModel;
using System.Diagnostics;
using LibUvgaFile;

/// <summary>
/// Implements a background worker that edits a file and waits until the editing process is closed again.
/// </summary>
internal class BgwEditItem
    : BackgroundWorker
{
    /// <inheritdoc/>
    protected override void OnDoWork(DoWorkEventArgs e)
    {
        var data = e.Argument as EditItemWorkerData;
        if (data == null)
        {
            e.Result = data;
            return;
        }

        string tempfile = string.Empty;
        try
        {
            var temppath = Path.GetTempPath();
            tempfile = Path.Combine(temppath, Guid.NewGuid().ToString() + ".png");
            File.WriteAllBytes(tempfile, [.. data.Item.Source.ImageData]);
            var psi = new ProcessStartInfo(tempfile)
            {
                UseShellExecute = true,
                Verb = "edit",
            };

            psi.ArgumentList.Add(tempfile);
            var proc = Process.Start(psi);
            if (proc == null)
            {
                return;
            }

            var spinner = default(SpinWait);
            while (!proc.HasExited)
            {
                spinner.SpinOnce();
            }

            var readback = File.ReadAllBytes(tempfile);
            readback = UvgaOperations.FixImageData(readback);
            var newSource = new UvgaImageContent(data.Item.Name, readback);
            var newItem = new UvgaImageFile(newSource);
            data.NewItem = newItem;
            data.Success = true;
            e.Result = data;
            return;
        }
        catch (Exception)
        {
            data.Success = false;
        }
        finally
        {
            File.Delete(tempfile);
        }
    }
}
