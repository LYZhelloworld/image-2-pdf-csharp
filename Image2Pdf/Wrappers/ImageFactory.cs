// <copyright file="ImageFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Layout.Element;

    /// <summary>
    /// Implementation of <see cref="IImageDataFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class ImageFactory : IImageFactory
    {
        /// <inheritdoc/>
        public IImage FromImageData(IImageData imageData)
        {
            return new ImageWrapper(new Image(imageData.Unwrap()));
        }
    }
}