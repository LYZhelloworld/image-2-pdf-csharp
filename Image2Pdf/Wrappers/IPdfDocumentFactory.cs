using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The factory class of <see cref="IPdfDocument"/>.
/// </summary>
public interface IPdfDocumentFactory
{
    /// <summary>
    /// The wrapper class of <see cref="PdfDocument(PdfReader)"/>.
    /// </summary>
    /// <param name="pdfWriter">The <see cref="IPdfWriter"/> object.</param>
    /// <returns>The <see cref="IPdfDocument"/> instance.</returns>
    public IPdfDocument FromPdfWriter(IPdfWriter pdfWriter);
}
