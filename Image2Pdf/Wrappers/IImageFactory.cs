namespace Image2Pdf.Wrappers;

/// <summary>
/// The factory class of <see cref="IImage"/>.
/// </summary>
public interface IImageFactory
{
    /// <summary>
    /// The wrapper method of <see cref="iText.Layout.Element.Image.Image(iText.IO.Image.ImageData)"/>.
    /// </summary>
    /// <param name="imageData">The <see cref="IImageData"/> object.</param>
    /// <returns>The <see cref="IImage"/> instance.</returns>
    IImage FromImageData(IImageData imageData);
}
