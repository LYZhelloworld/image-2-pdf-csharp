// <copyright file="ImageDataFactoryWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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