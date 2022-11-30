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
        /// <inheritdoc cref="PdfDocument(PdfReader)"/>
        public IPdfDocument FromPdfWriter(IPdfWriter reader);
    }
}
