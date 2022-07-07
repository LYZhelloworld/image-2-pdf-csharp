using System;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="iText.Kernel.Pdf.PdfWriter"/>.
/// </summary>
public interface IPdfWriter : IDisposable
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    internal PdfWriter PdfWriter { get; }
}
