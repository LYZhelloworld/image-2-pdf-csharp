using System;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="iText.Kernel.Pdf.PdfDocument"/>.
/// </summary>
public interface IPdfDocument : IDisposable
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    internal PdfDocument PdfDocument { get; }

    /// <summary>
    /// The wrapper method of <see cref="PdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize)"/>.
    /// </summary>
    /// <param name="pageSize">The page size.</param>
    void SetDefaultPageSize(IPageSize pageSize);

    /// <summary>
    /// The wrapper method of <see cref="PdfDocument.Close"/>.
    /// </summary>
    void Close();
}
