// <copyright file="ISystemDrawingImage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System;
    using System.Drawing;

    /// <summary>
    /// The wrapper class of <see cref="Image"/>.
    /// </summary>
    public interface ISystemDrawingImage : IWrapper<Image>, IDisposable
    {
        /// <summary>
        /// Gets the wrapped property of <see cref="Image.Width"/>.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the wrapped property of <see cref="Image.Height"/>.
        /// </summary>
        int Height { get; }
    }
}