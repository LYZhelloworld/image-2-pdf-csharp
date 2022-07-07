using System.Diagnostics.CodeAnalysis;
using iText.IO.Image;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The implementation of <see cref="IImageDataFactory"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ImageDataFactoryWrapper : IImageDataFactory
{
    /// <inheritdoc/>
    public IImageData Create(string imageFilename)
    {
        return new ImageDataWrapper(ImageDataFactory.Create(imageFilename));
    }
}
