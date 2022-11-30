// <copyright file="ImageWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using System.Diagnostics.CodeAnalysis;
    using Image2Pdf.Wrappers;
    using iText.Layout.Element;

    /// <inheritdoc cref="IImage"/>
    [ExcludeFromCodeCoverage]
    internal class ImageWrapper : Wrapper<Image>, IImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageWrapper"/> class.
        /// </summary>
        /// <param name="image">The wrapped object.</param>
        internal ImageWrapper(Image image)
            : base(image)
        {
        }
    }
}
