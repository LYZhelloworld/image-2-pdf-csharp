using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPdfWriter"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PdfWriterWrapper : IPdfWriter
{
    /// <inheritdoc/>
    public PdfWriter PdfWriter { get; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="pdfWriter">The wrapped object.</param>
    internal PdfWriterWrapper(PdfWriter pdfWriter)
    {
        PdfWriter = pdfWriter;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        PdfWriter.Dispose();
    }
}
