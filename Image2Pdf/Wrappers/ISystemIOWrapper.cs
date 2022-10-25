// <copyright file="ISystemIOWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    /// <summary>
    /// The wrapper class of <see cref="System.IO"/> operations.
    /// </summary>
    public interface ISystemIOWrapper
    {
        /// <summary>
        /// Gets the wrapper object of <see cref="System.IO.FileStream"/>.
        /// </summary>
        IFileStreamFactory FileStream { get; }
    }
}
