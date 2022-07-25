// <copyright file="FileStreamFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    /// Implementation of <see cref="IFileStreamFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class FileStreamFactory : IFileStreamFactory
    {
        /// <inheritdoc/>
        public Stream CreateFileStream(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStream(path, mode, access, share);
        }
    }
}