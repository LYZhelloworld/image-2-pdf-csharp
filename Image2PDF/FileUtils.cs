using System.Collections.Generic;
using System.Linq;

namespace Image2PDF
{
    internal static class FileUtils
    {
        private static readonly List<string> supportedExtNames = new() { ".jpg", ".png" };

        /// <summary>
        /// Check if the filename given is a image file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>True if the file is an image, false otherwise.</returns>
        public static bool IsValidImageFile(string filename)
        {
            return supportedExtNames.Any(delegate (string ext)
            {
                return filename.EndsWith(ext);
            });
        }
    }
}
