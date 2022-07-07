using System.Diagnostics.CodeAnalysis;
using iText.Layout;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IDocumentFactory"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class DocumentFactory : IDocumentFactory
{
    /// <inheritdoc/>
    public IDocument FromPdfDocument(IPdfDocument pdfDocument)
    {
        return new DocumentWrapper(new Document(pdfDocument.PdfDocument));
    }
}
