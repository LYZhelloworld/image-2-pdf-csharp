using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="ISystemDrawingImage"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class SystemDrawingImageWrapper : Wrapper<Image>, ISystemDrawingImage
{
    /// <inheritdoc/>
    public int Width { get => Unwrap().Width; }

    /// <inheritdoc/>
    public int Height { get => Unwrap().Height; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="image">The wrapped object.</param>
    internal SystemDrawingImageWrapper(Image image)
        : base(image)
    {
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Unwrap().Dispose();
    }
}
