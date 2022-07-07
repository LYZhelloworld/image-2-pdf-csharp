using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPdfDocument"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PdfDocumentWrapper : IPdfDocument
{
    /// <inheritdoc/>
    public PdfDocument PdfDocument { get; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="pdfDocument">The wrapped class.</param>
    internal PdfDocumentWrapper(PdfDocument pdfDocument)
    {
        PdfDocument = pdfDocument;
    }

    /// <inheritdoc/>
    public void SetDefaultPageSize(IPageSize pageSize)
    {
        PdfDocument.SetDefaultPageSize(pageSize.PageSize);
    }

    /// <inheritdoc/>
    public void Close()
    {
        PdfDocument.Close();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Close();
    }
}
