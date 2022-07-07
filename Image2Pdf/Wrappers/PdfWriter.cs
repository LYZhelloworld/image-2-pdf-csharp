using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPdfWriter"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PdfWriterWrapper : Wrapper<PdfWriter>, IPdfWriter
{
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="pdfWriter">The wrapped object.</param>
    internal PdfWriterWrapper(PdfWriter pdfWriter)
        : base(pdfWriter)
    {
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Unwrap().Dispose();
    }
}
