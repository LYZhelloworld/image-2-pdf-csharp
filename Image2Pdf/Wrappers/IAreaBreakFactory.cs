using iText.Layout.Properties;

namespace Image2Pdf.Wrappers;

/// <summary>
/// A factory class of <see cref="IAreaBreak"/>.
/// </summary>
public interface IAreaBreakFactory
{
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    /// <summary>
    /// The wrapper method of <see cref="iText.Layout.Element.AreaBreak.AreaBreak"/>.
    /// </summary>
    /// <param name="areaBreakType">An area break type.</param>
    /// <returns>The <see cref="IAreaBreak"/> instance.</returns>
    IAreaBreak FromAreaBreakType(AreaBreakType areaBreakType);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
}
