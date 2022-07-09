using System.IO;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The factory class of <see cref="ISystemDrawingImage"/>.
/// </summary>
public interface ISystemDrawingImageFactory
{
    /// <summary>
    /// The wrapper method of <see cref="System.Drawing.Image.FromStream(Stream, bool, bool)"/>.
    /// </summary>
    /// <param name="fileStream">The file stream.</param>
    /// <param name="useEmbeddedColorManagement">Whether to use embedded color management.</param>
    /// <param name="validateImageData">Whether to validate image data.</param>
    /// <returns></returns>
    ISystemDrawingImage FromStream(Stream fileStream, bool useEmbeddedColorManagement, bool validateImageData);
}
