// <copyright file="ImageWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Layout.Element;

    /// <summary>
    /// Implementation of <see cref="IImage"/>.
    /// </summary>
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
