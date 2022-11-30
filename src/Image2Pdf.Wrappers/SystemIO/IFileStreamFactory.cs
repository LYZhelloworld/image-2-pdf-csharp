// <copyright file="IFileStreamFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.SystemIO
{
    using System.IO;

    /// <summary>
    /// The factory class of <see cref="FileStream"/>.
    /// </summary>
    public interface IFileStreamFactory
    {
        /// <inheritdoc cref="FileStream(string, FileMode, FileAccess, FileShare)"/>
        Stream CreateInstance(string path, FileMode mode, FileAccess access, FileShare share);
    }
}
