// <copyright file="IPdfDocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using iText.Kernel.Pdf;

    /// <summary>
    /// The factory class of <see cref="IPdfDocument"/>.
    /// </summary>
    public interface IPdfDocumentFactory
    {
        /// <summary>
        /// The wrapper class of <see cref="PdfDocument(PdfReader)"/>.
        /// </summary>
        /// <param name="pdfWriter">The <see cref="IPdfWriter"/> object.</param>
        /// <returns>The <see cref="IPdfDocument"/> instance.</returns>
        public IPdfDocument FromPdfWriter(IPdfWriter pdfWriter);
    }
}
