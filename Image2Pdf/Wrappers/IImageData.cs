using iText.IO.Image;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="iText.IO.Image.ImageData"/>.
/// </summary>
public interface IImageData
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    internal ImageData ImageData { get; }
}
