// <copyright file="IImageDataFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using iText.IO.Image;

    /// <summary>
    /// The factory class of <see cref="IImageData"/>.
    /// </summary>
    public interface IImageDataFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="ImageDataFactory.Create(string)"/>.
        /// </summary>
        /// <param name="imageFilename">The filename of the file containing the image.</param>
        /// <returns>The <see cref="IImageData"/> instance.</returns>
        IImageData Create(string imageFilename);
    }
}
