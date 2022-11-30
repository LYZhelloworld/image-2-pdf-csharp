// <copyright file="IImageFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.IO.Image;
    using iText.Layout.Element;

    /// <summary>
    /// The factory class of <see cref="IImage"/>.
    /// </summary>
    public interface IImageFactory
    {
        /// <inheritdoc cref="Image(ImageData)"/>
        IImage CreateInstance(IImageData img);
    }
}
