using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPdfDocumentFactory"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PdfDocumentFactory : IPdfDocumentFactory
{
    /// <inheritdoc/>
    public IPdfDocument FromPdfWriter(IPdfWriter pdfWriter)
    {
        return new PdfDocumentWrapper(new PdfDocument(pdfWriter.PdfWriter));
    }
}
