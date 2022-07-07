using iText.Layout.Element;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="iText.Layout.Element.Image"/>.
/// </summary>
public interface IImage
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    internal Image Image { get; }
}
