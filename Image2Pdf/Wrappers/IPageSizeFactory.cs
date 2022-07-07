namespace Image2Pdf.Wrappers;

/// <summary>
/// The factory class of <see cref="IPageSize"/>.
/// </summary>
public interface IPageSizeFactory
{
    /// <summary>
    /// The wrapper method of <see cref="iText.Kernel.Geom.PageSize.PageSize(float, float)"/>.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The <see cref="IPageSize"/> instance.</returns>
    IPageSize FromWidthAndHeight(float width, float height);
}
