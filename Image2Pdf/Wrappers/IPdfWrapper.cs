namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="iText"/> operations.
/// </summary>
public interface IPdfWrapper
{
    /// <summary>
    /// The wrapper object of <see cref="iText.Kernel.Pdf.PdfWriter"/>.
    /// </summary>
    IPdfWriterFactory PdfWriter { get; }

    /// <summary>
    /// The wrapper object of <see cref="iText.Kernel.Pdf.PdfDocument"/>.
    /// </summary>
    IPdfDocumentFactory PdfDocument { get; }

    /// <summary>
    /// The wrapper object of <see cref="iText.Layout.Document"/>.
    /// </summary>
    IDocumentFactory Document { get; }

    /// <summary>
    /// The wrapper object of <see cref="iText.Kernel.Geom.PageSize"/>.
    /// </summary>
    IPageSizeFactory PageSize { get; }

    /// <summary>
    /// The wrapper object of <see cref="iText.Layout.Element.AreaBreak"/>.
    /// </summary>
    IAreaBreakFactory AreaBreak { get; }

    /// <summary>
    /// The wrapper object of <see cref="iText.IO.Image.ImageDataFactory"/>.
    /// </summary>
    IImageDataFactory ImageDataFactory { get; }

    /// <summary>
    /// The wrapper object of <see cref="iText.Layout.Element.Image"/>.
    /// </summary>
    IImageFactory Image { get; }
}
