// <copyright file="IImageFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using iText.IO.Image;
    using iText.Layout.Element;

    /// <summary>
    /// The factory class of <see cref="IImage"/>.
    /// </summary>
    public interface IImageFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="Image(ImageData)"/>.
        /// </summary>
        /// <param name="imageData">The <see cref="IImageData"/> object.</param>
        /// <returns>The <see cref="IImage"/> instance.</returns>
        IImage FromImageData(IImageData imageData);
    }
}