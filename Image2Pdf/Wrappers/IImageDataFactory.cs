using iText.IO.Image;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The factory class of <see cref="IImageData"/>.
/// </summary>
public interface IImageDataFactory
{
    /// <summary>
    /// The wrapper method of <see cref="ImageDataFactory.Create(string)"/>.
    /// </summary>
    /// <param name="imageFilename">The filename of the file containing the image.</param>
    /// <returns>The <see cref="IImageData"/> instance.</returns>
    IImageData Create(string imageFilename);
}
