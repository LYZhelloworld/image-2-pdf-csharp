using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="ISystemDrawingImageFactory"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class SystemDrawingImageFactory : ISystemDrawingImageFactory
{
    /// <inheritdoc/>
    public ISystemDrawingImage FromStream(Stream stream, bool useEmbeddedColorManagement, bool validateImageData)
    {
        return new SystemDrawingImageWrapper(Image.FromStream(stream, useEmbeddedColorManagement, validateImageData));
    }
}
