namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="System.Drawing"/> operations.
/// </summary>
public interface ISystemDrawingWrapper
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    ISystemDrawingImageFactory Image { get; }
}
