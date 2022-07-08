using System.Collections.Generic;

namespace Image2Pdf.Generators;

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
    public IPdfGeneratorFactory AddFiles(IEnumerable<string> files)
    {
        _files.AddRange(files);
        return this;
    }

    /// <inheritdoc/>
    public IPdfGenerator Build()
    {
        return new PdfGenerator(_files);
    }
}
