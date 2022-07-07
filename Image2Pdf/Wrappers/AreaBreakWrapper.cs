using System.Diagnostics.CodeAnalysis;
using iText.Layout.Element;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IAreaBreak"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class AreaBreakWrapper : IAreaBreak
{
    /// <inheritdoc/>
    public AreaBreak AreaBreak { get; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="areaBreak">The wrapped object.</param>
    internal AreaBreakWrapper(AreaBreak areaBreak)
    {
        AreaBreak = areaBreak;
    }
}
