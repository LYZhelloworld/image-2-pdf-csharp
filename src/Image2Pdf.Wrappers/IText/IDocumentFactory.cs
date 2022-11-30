// <copyright file="IDocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.Layout;

    /// <summary>
    /// The factory class of <see cref="IDocument"/>.
    /// </summary>
    public interface IDocumentFactory
    {
        /// <inheritdoc cref="Document(iText.Kernel.Pdf.PdfDocument)"/>
        IDocument FromPdfDocument(IPdfDocument pdfDoc);
    }
}
