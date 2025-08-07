// <copyright file="UvgaCollection.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer;

using LibUvgaFile;

/// <summary>
/// Implements a list of <see cref="UvgaImageFile"/> objects.
/// </summary>
internal class UvgaCollection
    : List<UvgaImageFile>, IDisposable
{
    private bool disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="UvgaCollection"/> class.
    /// </summary>
    /// <param name="file">The source <see cref="UvgaFile"/>.</param>
    public UvgaCollection(UvgaFile file)
        : base()
    {
        foreach (var item in file.Images)
        {
            this.Add(new UvgaImageFile(item));
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose the object.
    /// </summary>
    /// <param name="disposing">If disposing managed content.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                foreach (var i in this)
                {
                    i.Dispose();
                }

                this.Clear();
            }

            this.disposedValue = true;
        }
    }
}