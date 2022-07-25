// <copyright file="ISystemIOWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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