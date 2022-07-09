using System.Linq;

namespace Image2Pdf.Utilities;

/// <summary>
/// The utility class of file operations.
/// </summary>
public static class FileUtils
{
    /// <summary>
    /// Supported extension names.
    /// </summary>
    private static readonly string[] s_supportedExtNames = new string[] { ".jpg", ".png" };

    /// <summary>
    /// Checks if the filename given is a image file.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns><c>true</c> if the file is an image, <c>false</c> otherwise.</returns>
    public static bool IsValidImageFile(string filename)
    {
        return s_supportedExtNames.Any(ext => filename.EndsWith(ext, System.StringComparison.OrdinalIgnoreCase));
    }
}
