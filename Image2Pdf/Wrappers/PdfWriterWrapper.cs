// <copyright file="PdfWriterWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Kernel.Pdf;

    /// <summary>
    /// Implementation of <see cref="IPdfWriter"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
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
