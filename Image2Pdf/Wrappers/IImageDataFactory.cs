// <copyright file="IImageDataFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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