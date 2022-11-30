// <copyright file="DocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Layout;

    /// <inheritdoc cref="IDocumentFactory"/>
    [ExcludeFromCodeCoverage]
    internal class DocumentFactory : IDocumentFactory
    {
        /// <inheritdoc/>
        public IDocument FromPdfDocument(IPdfDocument pdfDoc)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            return new DocumentWrapper(new Document(pdfDoc.Unwrap()));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }
    }
}
