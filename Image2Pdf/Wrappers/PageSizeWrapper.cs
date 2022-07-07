using System.Diagnostics.CodeAnalysis;
using iText.Kernel.Geom;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IPageSize"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PageSizeWrapper : Wrapper<PageSize>, IPageSize
{
    /// <summary>
    /// The constrctor.
    /// </summary>
    /// <param name="pageSize">The wrapped object.</param>
    internal PageSizeWrapper(PageSize pageSize)
        : base(pageSize)
    {
    }
}
