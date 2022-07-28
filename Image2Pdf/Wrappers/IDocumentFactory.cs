// <copyright file="IDocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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