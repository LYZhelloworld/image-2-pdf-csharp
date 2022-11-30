// <copyright file="DocumentFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.Layout;

    /// <inheritdoc cref="IDocumentFactory"/>
    internal class DocumentFactory : IDocumentFactory
    {
        /// <inheritdoc/>
        public IDocument CreateInstance(IPdfDocument pdfDoc)
        {
            return new DocumentWrapper(new Document(pdfDoc.Unwrap()));
        }
    }
}
