using iText.Kernel.Geom;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="iText.Kernel.Geom.PageSize"/>.
/// </summary>
public interface IPageSize
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    internal PageSize PageSize { get; }
}
