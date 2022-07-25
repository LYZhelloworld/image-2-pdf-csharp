// <copyright file="IDocumentFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using iText.Layout;

    /// <summary>
    /// The factory class of <see cref="IDocument"/>.
    /// </summary>
    public interface IDocumentFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="Document(iText.Kernel.Pdf.PdfDocument)"/>.
        /// </summary>
        /// <param name="pdfDocument">The <see cref="IPdfDocument"/> object.</param>
        /// <returns>The <see cref="IDocument"/> instance.</returns>
        IDocument FromPdfDocument(IPdfDocument pdfDocument);
    }
}