// <copyright file="DocumentFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
#pragma warning disable CA2000 // Dispose objects before losing scope
            return new DocumentWrapper(new Document(pdfDocument.Unwrap()));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }
    }
}