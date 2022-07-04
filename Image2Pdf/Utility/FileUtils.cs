namespace Image2Pdf.Utility
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The utility class of file operations.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Supported extension names.
        /// </summary>
        private static readonly List<string> supportedExtNames = new() { ".jpg", ".png" };

        /// <summary>
        /// Checks if the filename given is a image file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns><c>true</c> if the file is an image, <c>false</c> otherwise.</returns>
        public static bool IsValidImageFile(string filename)
        {
            return supportedExtNames.Any(delegate (string ext)
            {
                return filename.EndsWith(ext, System.StringComparison.OrdinalIgnoreCase);
            });
        }
    }
}
