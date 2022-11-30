// <copyright file="PdfDocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Kernel.Pdf;

    /// <inheritdoc cref="IPdfDocumentFactory"/>
    [ExcludeFromCodeCoverage]
    internal class PdfDocumentFactory : IPdfDocumentFactory
    {
        /// <inheritdoc/>
        public IPdfDocument FromPdfWriter(IPdfWriter reader)
        {
            return new PdfDocumentWrapper(new PdfDocument(reader.Unwrap()));
        }
    }
}
