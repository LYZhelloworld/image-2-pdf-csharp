using System;
using iText.Kernel.Pdf;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="PdfWriter"/>.
/// </summary>
public interface IPdfWriter : IWrapper<PdfWriter>, IDisposable
{
}
