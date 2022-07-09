using System.Diagnostics.CodeAnalysis;
using iText.IO.Image;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IImageData"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ImageDataWrapper : Wrapper<ImageData>, IImageData
{
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="imageData">The wrapped object.</param>
    internal ImageDataWrapper(ImageData imageData)
        : base(imageData)
    {
    }
}
