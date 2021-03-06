// <copyright file="ImageDataFactoryWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.IO.Image;

    /// <summary>
    /// The implementation of <see cref="IImageDataFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class ImageDataFactoryWrapper : IImageDataFactory
    {
        /// <inheritdoc/>
        public IImageData Create(string imageFilename)
        {
            return new ImageDataWrapper(ImageDataFactory.Create(imageFilename));
        }
    }
}