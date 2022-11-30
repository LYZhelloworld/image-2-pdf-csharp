// <copyright file="PdfWriterWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using Image2Pdf.Wrappers;
    using iText.Kernel.Pdf;

    /// <inheritdoc cref="IPdfWriter"/>
    internal class PdfWriterWrapper : Wrapper<PdfWriter>, IPdfWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfWriterWrapper"/> class.
        /// </summary>
        /// <param name="pdfWriter">The wrapped object.</param>
        internal PdfWriterWrapper(PdfWriter pdfWriter)
            : base(pdfWriter)
        {
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Unwrap().Dispose();
        }
    }
}
