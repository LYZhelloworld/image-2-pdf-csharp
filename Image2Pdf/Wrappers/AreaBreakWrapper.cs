using System.Diagnostics.CodeAnalysis;
using iText.Layout.Element;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IAreaBreak"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class AreaBreakWrapper : Wrapper<AreaBreak>, IAreaBreak
{
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="areaBreak">The wrapped object.</param>
    internal AreaBreakWrapper(AreaBreak areaBreak)
        : base(areaBreak)
    {
    }
}
