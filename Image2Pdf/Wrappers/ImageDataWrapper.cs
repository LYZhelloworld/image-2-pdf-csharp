// <copyright file="ImageDataWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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
