// <copyright file="PdfAdapterFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Adapters
{
    using Image2Pdf.Wrappers;

    /// <summary>
    /// The factory class of <see cref="IPdfAdapter"/>.
    /// </summary>
    public class PdfAdapterFactory : IPdfAdapterFactory
    {
        /// <summary>
        /// The wrapper class of <see cref="iText"/> operations.
        /// </summary>
        private readonly IPdfWrapper pdfWrapper;

        /// <summary>
        /// The wrapper class of <see cref="System.IO"/> operations.
        /// </summary>
        private readonly ISystemIOWrapper systemIOWrapper;

        /// <summary>
        /// The wrapper class of <see cref="System.Drawing"/> operations.
        /// </summary>
        private readonly ISystemDrawingWrapper systemDrawingWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAdapterFactory"/> class.
        /// </summary>
        /// <param name="pdfWrapper">The wrapper class of <see cref="iText"/> operations.</param>
        /// <param name="systemIOWrapper">The wrapper class of <see cref="System.IO"/> operations.</param>
        /// <param name="systemDrawingWrapper">The wrapper class of <see cref="System.Drawing"/> operations.</param>
        public PdfAdapterFactory(IPdfWrapper pdfWrapper, ISystemIOWrapper systemIOWrapper, ISystemDrawingWrapper systemDrawingWrapper)
        {
            this.pdfWrapper = pdfWrapper;
            this.systemIOWrapper = systemIOWrapper;
            this.systemDrawingWrapper = systemDrawingWrapper;
        }

        /// <inheritdoc/>
        public IPdfAdapter CreateInstance(string pdfFileName)
        {
            return new PdfAdapter(pdfFileName, this.pdfWrapper, this.systemIOWrapper, this.systemDrawingWrapper);
        }
    }
}
