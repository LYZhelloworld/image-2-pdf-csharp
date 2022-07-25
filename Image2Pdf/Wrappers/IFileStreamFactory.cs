// <copyright file="IFileStreamFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.IO;

    /// <summary>
    /// The factory class of <see cref="Stream"/>.
    /// </summary>
    public interface IFileStreamFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="FileStream(string, FileMode, FileAccess, FileShare)"/>.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <param name="mode">The mode that determines how to open or create the file.</param>
        /// <param name="access">The value that determines how the file can be accessed.</param>
        /// <param name="share">The value that determines how the file will be shared by processes.</param>
        /// <returns>The <see cref="Stream"/> instance.</returns>
        Stream CreateFileStream(string path, FileMode mode, FileAccess access, FileShare share);
    }
}