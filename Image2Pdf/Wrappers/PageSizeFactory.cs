using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Geom;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPageSizeFactory"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PageSizeFactory : IPageSizeFactory
{
    /// <inheritdoc/>
    public IPageSize FromWidthAndHeight(float width, float height)
    {
        return new PageSizeWrapper(new PageSize(width, height));
    }
}
