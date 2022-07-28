// <copyright file="PdfDocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Kernel.Pdf;

    /// <summary>
    /// Implementation of <see cref="IPdfDocumentFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class PdfDocumentFactory : IPdfDocumentFactory
    {
        /// <inheritdoc/>
        public IPdfDocument FromPdfWriter(IPdfWriter pdfWriter)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            return new PdfDocumentWrapper(new PdfDocument(pdfWriter.Unwrap()));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }
    }
}