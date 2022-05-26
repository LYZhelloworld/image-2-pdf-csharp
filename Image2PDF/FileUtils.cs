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

        /// <summary>
        /// Check if the filenames given are all image files.
        /// </summary>
        /// <param name="files">The filenames.</param>
        /// <returns>True if all files are image files, false otherwise.</returns>
        public static bool IsValidImageFiles(List<string> files)
        {
            return files.TrueForAll(IsValidImageFile);
        }
    }
}
