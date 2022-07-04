using System.Collections.Generic;
using Image2Pdf.Generator;

namespace Image2Pdf.Interfaces;

/// <summary>
/// The factory class of <see cref="IPdfGenerator{TFileProcessedEventArgs, TPdfGenerationCompletedEventArgs}"/>.
/// </summary>
public interface IPdfGeneratorFactory
{
    /// <summary>
    /// Adds image filenames.
    /// </summary>
    /// <param name="files">The image filenames.</param>
    /// <returns>The current factory instance.</returns>
    PdfGeneratorFactory AddFiles(IEnumerable<string> files);

    /// <summary>
    /// Builds an instance of <see cref="IPdfGenerator{TFileProcessedEventArgs, TPdfGenerationCompletedEventArgs}"/>.
    /// </summary>
    /// <returns>The instance.</returns>
    IPdfGenerator<FileProcessedEventArgs, PdfGenerationCompletedEventArgs> Build();
}
