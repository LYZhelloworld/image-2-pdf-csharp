// <copyright file="ISystemDrawingImage.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System;
    using System.Drawing;

    /// <inheritdoc cref="Image"/>
    public interface ISystemDrawingImage : IWrapper<Image>, IDisposable
    {
        /// <inheritdoc cref="Image.Width"/>
        int Width { get; }

        /// <inheritdoc cref="Image.Height"/>
        int Height { get; }
    }
}
