using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPdfDocument"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PdfDocumentWrapper : Wrapper<PdfDocument>, IPdfDocument
{
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="pdfDocument">The wrapped class.</param>
    internal PdfDocumentWrapper(PdfDocument pdfDocument)
        : base(pdfDocument)
    {
    }

    /// <inheritdoc/>
    public void SetDefaultPageSize(IPageSize pageSize)
    {
        Unwrap().SetDefaultPageSize(pageSize.Unwrap());
    }

    /// <inheritdoc/>
    public void Close()
    {
        Unwrap().Close();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Close();
    }
}
