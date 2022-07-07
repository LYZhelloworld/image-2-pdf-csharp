using System.Diagnostics.CodeAnalysis;
using iText.Layout.Element;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IImage"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ImageWrapper : IImage
{
    /// <inheritdoc/>
    public Image Image { get; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="image">The wrapped object.</param>
    internal ImageWrapper(Image image)
    {
        Image = image;
    }
}
