// <copyright file="PdfDocumentWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Kernel.Pdf;

    /// <summary>
    /// Implementation of <see cref="IPdfDocument"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class PdfDocumentWrapper : Wrapper<PdfDocument>, IPdfDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfDocumentWrapper"/> class.
        /// </summary>
        /// <param name="pdfDocument">The wrapped class.</param>
        internal PdfDocumentWrapper(PdfDocument pdfDocument)
            : base(pdfDocument)
        {
        }

        /// <inheritdoc/>
        public void SetDefaultPageSize(IPageSize pageSize)
        {
            this.Unwrap().SetDefaultPageSize(pageSize.Unwrap());
        }

        /// <inheritdoc/>
        public void Close()
        {
            this.Unwrap().Close();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Close();
        }
    }
}
