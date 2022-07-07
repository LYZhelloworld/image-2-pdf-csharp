using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPdfWriterFactory"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PdfWriterFactory : IPdfWriterFactory
{
    /// <inheritdoc/>
    public IPdfWriter FromFilename(string filename)
    {
        return new PdfWriterWrapper(new PdfWriter(filename));
    }
}
