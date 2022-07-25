// <copyright file="ImageDataWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.IO.Image;

    /// <summary>
    /// Implementation of <see cref="IImageData"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class ImageDataWrapper : Wrapper<ImageData>, IImageData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageDataWrapper"/> class.
        /// </summary>
        /// <param name="imageData">The wrapped object.</param>
        internal ImageDataWrapper(ImageData imageData)
            : base(imageData)
        {
        }
    }
}
