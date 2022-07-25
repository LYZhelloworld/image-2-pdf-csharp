// <copyright file="IPdfWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    /// <summary>
    /// The wrapper class of <see cref="iText"/> operations.
    /// </summary>
    public interface IPdfWrapper
    {
        /// <summary>
        /// Gets the wrapper object of <see cref="iText.Kernel.Pdf.PdfWriter"/>.
        /// </summary>
        IPdfWriterFactory PdfWriter { get; }

        /// <summary>
        /// Gets the wrapper object of <see cref="iText.Kernel.Pdf.PdfDocument"/>.
        /// </summary>
        IPdfDocumentFactory PdfDocument { get; }

        /// <summary>
        /// Gets the wrapper object of <see cref="iText.Layout.Document"/>.
        /// </summary>
        IDocumentFactory Document { get; }

        /// <summary>
        /// Gets the wrapper object of <see cref="iText.Kernel.Geom.PageSize"/>.
        /// </summary>
        IPageSizeFactory PageSize { get; }

        /// <summary>
        /// Gets the wrapper object of <see cref="iText.Layout.Element.AreaBreak"/>.
        /// </summary>
        IAreaBreakFactory AreaBreak { get; }

        /// <summary>
        /// Gets the wrapper object of <see cref="iText.IO.Image.ImageDataFactory"/>.
        /// </summary>
        IImageDataFactory ImageDataFactory { get; }

        /// <summary>
        /// Gets the wrapper object of <see cref="iText.Layout.Element.Image"/>.
        /// </summary>
        IImageFactory Image { get; }
    }
}