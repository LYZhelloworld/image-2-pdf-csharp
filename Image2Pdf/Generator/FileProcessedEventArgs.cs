using System;
using System.Diagnostics.CodeAnalysis;

namespace Image2Pdf.Generator;

/// <summary>
/// The arguments of the file processed event.
/// </summary>
[ExcludeFromCodeCoverage]
public class FileProcessedEventArgs : EventArgs
{
    /// <summary>
    /// The file processed.
    /// </summary>
    public string Filename { get; init; }

    /// <summary>
    /// The number of files processed.
    /// </summary>
    public int Progress { get; init; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="filename">The file processed.</param>
    /// <param name="progress">The number of files processed.</param>
    public FileProcessedEventArgs(string filename, int progress)
    {
        Filename = filename;
        Progress = progress;
    }
}
