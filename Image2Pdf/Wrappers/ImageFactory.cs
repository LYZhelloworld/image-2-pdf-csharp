// <copyright file="ImageFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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
