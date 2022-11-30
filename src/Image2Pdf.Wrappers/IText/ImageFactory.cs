// <copyright file="ImageFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.Layout.Element;

    /// <inheritdoc cref="IImageFactory"/>
    internal class ImageFactory : IImageFactory
    {
        /// <inheritdoc/>
        public IImage FromImageData(IImageData img)
        {
            return new ImageWrapper(new Image(img.Unwrap()));
        }
    }
}
