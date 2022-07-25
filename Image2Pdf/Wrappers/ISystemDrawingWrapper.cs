// <copyright file="ISystemDrawingWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    /// <summary>
    /// The wrapper class of <see cref="System.Drawing"/> operations.
    /// </summary>
    public interface ISystemDrawingWrapper
    {
        /// <summary>
        /// Gets the wrapper object of <see cref="System.Drawing.Image"/>.
        /// </summary>
        ISystemDrawingImageFactory Image { get; }
    }
}