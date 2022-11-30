// <copyright file="ImageDataWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using Image2Pdf.Wrappers;
    using iText.IO.Image;

    /// <inheritdoc cref="IImageData"/>
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
