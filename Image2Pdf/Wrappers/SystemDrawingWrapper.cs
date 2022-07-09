using System.Diagnostics.CodeAnalysis;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="ISystemDrawingWrapper"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class SystemDrawingWrapper : ISystemDrawingWrapper
{
    /// <inheritdoc/>
    public ISystemDrawingImageFactory Image { get; } = new SystemDrawingImageFactory();
}
