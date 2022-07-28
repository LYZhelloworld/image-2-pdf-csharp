// <copyright file="ISystemDrawingImage.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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