// <copyright file="PdfWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implementation of <see cref="IPdfWrapper"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PdfWrapper : IPdfWrapper
    {
        /// <inheritdoc/>
        public IPdfWriterFactory PdfWriter { get; } = new PdfWriterFactory();

        /// <inheritdoc/>
        public IPdfDocumentFactory PdfDocument { get; } = new PdfDocumentFactory();

        /// <inheritdoc/>
        public IDocumentFactory Document { get; } = new DocumentFactory();

        /// <inheritdoc/>
        public IPageSizeFactory PageSize { get; } = new PageSizeFactory();

        /// <inheritdoc/>
        public IAreaBreakFactory AreaBreak { get; } = new AreaBreakFactory();

        /// <inheritdoc/>
        public IImageFactory Image { get; } = new ImageFactory();

        /// <inheritdoc/>
        public IImageDataFactory ImageDataFactory { get; } = new ImageDataFactoryWrapper();
    }
}