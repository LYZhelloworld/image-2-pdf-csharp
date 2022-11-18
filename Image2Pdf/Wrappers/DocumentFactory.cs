// <copyright file="DocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Layout;

    /// <summary>
    /// Implementation of <see cref="IDocumentFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class DocumentFactory : IDocumentFactory
    {
        /// <inheritdoc/>
        public IDocument FromPdfDocument(IPdfDocument pdfDocument)
        {
            return new DocumentWrapper(new Document(pdfDocument.Unwrap()));
        }
    }
}
