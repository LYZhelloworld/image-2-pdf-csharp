using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="ISystemDrawingImage"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class SystemDrawingImageWrapper : ISystemDrawingImage
{
    /// <inheritdoc/>
    public Image Image { get; }

    /// <inheritdoc/>
    public int Width { get => Image.Width; }

    /// <inheritdoc/>
    public int Height { get => Image.Height; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="image">The wrapped object.</param>
    internal SystemDrawingImageWrapper(Image image)
    {
        Image = image;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Image.Dispose();
    }
}
