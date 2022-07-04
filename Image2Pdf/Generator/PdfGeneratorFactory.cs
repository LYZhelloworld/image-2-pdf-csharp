using System.Collections.Generic;
using Image2Pdf.Interfaces;

namespace Image2Pdf.Generator;

/// <inheritdoc/>
public class PdfGeneratorFactory : IPdfGeneratorFactory
{
    /// <summary>
    /// The image filenames.
    /// </summary>
    private readonly List<string> _files;

    /// <summary>
    /// The constructor.
    /// </summary>
    public PdfGeneratorFactory()
    {
        _files = new List<string>();
    }

    /// <inheritdoc/>
    public PdfGeneratorFactory AddFiles(IEnumerable<string> files)
    {
        _files.AddRange(files);
        return this;
    }

    /// <inheritdoc/>
    public IPdfGenerator<FileProcessedEventArgs, PdfGenerationCompletedEventArgs> Build()
    {
        return new PdfGenerator(_files);
    }
}
