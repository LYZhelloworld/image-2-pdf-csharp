// <copyright file="FileUtils.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Utilities
{
    using System.Linq;

    /// <summary>
    /// The utility class of file operations.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Supported extension names.
        /// </summary>
        private static readonly string[] SupportedExtNames = new string[] { ".jpg", ".jpeg", ".png" };

        /// <summary>
        /// Checks if the filename given is a image file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns><c>true</c> if the file is an image, <c>false</c> otherwise.</returns>
        public static bool IsValidImageFile(string filename)
        {
            return SupportedExtNames.Any(ext => filename.EndsWith(ext, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
