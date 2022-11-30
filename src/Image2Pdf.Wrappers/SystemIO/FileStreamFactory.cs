// <copyright file="FileStreamFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.SystemIO
{
    using System.IO;

    /// <inheritdoc cref="IFileStreamFactory"/>
    internal class FileStreamFactory : IFileStreamFactory
    {
        /// <inheritdoc/>
        public Stream CreateInstance(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStream(path, mode, access, share);
        }
    }
}
