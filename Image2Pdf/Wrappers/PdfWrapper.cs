using System.Diagnostics.CodeAnalysis;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPdfWrapper"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PdfWrapper : IPdfWrapper
{
    /// <inheritdoc/>
    public IPdfWriterFactory PdfWriter { get; } = new PdfWriterFactory();

    /// <inheritdoc/>
    public IPdfDocumentFactory PdfDocument { get; } = new PdfDocumentFactory();

    /// <inheritdoc/>
    public IDocumentFactory Document { get; } = new DocumentFactory();

    /// <inheritdoc/>
    public IPageSizeFactory PageSize { get; } = new PageSizeFactory();

    /// <inheritdoc/>
    public IAreaBreakFactory AreaBreak { get; } = new AreaBreakFactory();

    /// <inheritdoc/>
    public IImageFactory Image { get; } = new ImageFactory();

    /// <inheritdoc/>
    public IImageDataFactory ImageDataFactory { get; } = new ImageDataFactoryWrapper();
}
