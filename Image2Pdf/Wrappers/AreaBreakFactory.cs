using System.Diagnostics.CodeAnalysis;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IAreaBreakFactory"/>
/// </summary>
[ExcludeFromCodeCoverage]
internal class AreaBreakFactory : IAreaBreakFactory
{
    /// <inheritdoc/>
    public IAreaBreak FromAreaBreakType(AreaBreakType areaBreakType)
    {
        return new AreaBreakWrapper(new AreaBreak(areaBreakType));
    }
}
