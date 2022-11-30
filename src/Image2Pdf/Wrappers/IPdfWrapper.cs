// <copyright file="IPdfWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    /// <summary>
    /// The wrapper class of <see cref="iText"/> operations.
    /// </summary>
    public interface IPdfWrapper
    {
        /// <inheritdoc cref="IPdfWriterFactory"/>
        IPdfWriterFactory PdfWriter { get; }

        /// <inheritdoc cref="IPdfDocumentFactory"/>
        IPdfDocumentFactory PdfDocument { get; }

        /// <inheritdoc cref="IDocumentFactory"/>
        IDocumentFactory Document { get; }

        /// <inheritdoc cref="IPageSizeFactory"/>
        IPageSizeFactory PageSize { get; }

        /// <inheritdoc cref="IAreaBreakFactory"/>
        IAreaBreakFactory AreaBreak { get; }

        /// <inheritdoc cref="IImageDataFactory"/>
        IImageDataFactory ImageDataFactory { get; }

        /// <inheritdoc cref="IImageFactory"/>
        IImageFactory Image { get; }
    }
}
