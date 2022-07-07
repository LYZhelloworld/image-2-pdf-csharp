﻿using System.Diagnostics.CodeAnalysis;
using iText.Layout.Element;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IImage"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ImageWrapper : Wrapper<Image>, IImage
{
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="image">The wrapped object.</param>
    internal ImageWrapper(Image image)
        : base(image)
    {
    }
}
