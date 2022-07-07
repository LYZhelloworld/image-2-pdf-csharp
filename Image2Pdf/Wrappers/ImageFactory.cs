using System.Diagnostics.CodeAnalysis;
using iText.Layout.Element;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IImageDataFactory"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ImageFactory : IImageFactory
{
    /// <inheritdoc/>
    public IImage FromImageData(IImageData imageData)
    {
        return new ImageWrapper(new Image(imageData.ImageData));
    }
}
