// <copyright file="IImageDataFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.IO.Image;

    /// <inheritdoc cref="ImageDataFactory"/>
    public interface IImageDataFactory
    {
        /// <inheritdoc cref="ImageDataFactory.Create(string)"/>
        IImageData Create(string filename);
    }
}
