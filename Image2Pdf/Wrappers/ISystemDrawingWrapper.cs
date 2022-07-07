namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="System.Drawing"/> operations.
/// </summary>
public interface ISystemDrawingWrapper
{
    /// <summary>
    /// The wrapper object of <see cref="System.Drawing.Image"/>.
    /// </summary>
    ISystemDrawingImageFactory Image { get; }
}
