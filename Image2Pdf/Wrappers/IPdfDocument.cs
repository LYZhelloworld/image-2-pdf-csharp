using System;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="PdfDocument"/>.
/// </summary>
public interface IPdfDocument : IWrapper<PdfDocument>, IDisposable
{
    /// <summary>
    /// The wrapper method of <see cref="PdfDocument.SetDefaultPageSize(PageSize)"/>.
    /// </summary>
    /// <param name="pageSize">The page size.</param>
    void SetDefaultPageSize(IPageSize pageSize);

    /// <summary>
    /// The wrapper method of <see cref="PdfDocument.Close"/>.
    /// </summary>
    void Close();
}
