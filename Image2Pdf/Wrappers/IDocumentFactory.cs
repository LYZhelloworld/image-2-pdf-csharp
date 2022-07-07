namespace Image2Pdf.Wrappers;

/// <summary>
/// The factory class of <see cref="IDocument"/>.
/// </summary>
public interface IDocumentFactory
{
    /// <summary>
    /// The wrapper method of <see cref="iText.Layout.Document.Document(iText.Kernel.Pdf.PdfDocument)"/>.
    /// </summary>
    /// <param name="pdfDocument">The <see cref="IPdfDocument"/> object.</param>
    /// <returns>The <see cref="IDocument"/> instance.</returns>
    IDocument FromPdfDocument(IPdfDocument pdfDocument);
}
