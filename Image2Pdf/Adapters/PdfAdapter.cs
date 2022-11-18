// <copyright file="PdfAdapter.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Adapters
{
    using System;
    using System.IO;
    using Image2Pdf.Wrappers;
    using iText.Layout.Properties;

    /// <summary>
    /// The adapter of iText PDF generator.
    /// </summary>
    public sealed class PdfAdapter : IDisposable, IPdfAdapter
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
        /// The PDF document.
        /// </summary>
        private readonly IPdfDocument pdfDocument;

        /// <summary>
        /// The document.
        /// </summary>
        private readonly IDocument document;

        /// <summary>
        /// Indicates whether the current page is the first page.
        /// </summary>
        private bool isFirstPage = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAdapter"/> class.
        /// </summary>
        /// <param name="pdfFileName">The PDF filename.</param>
        /// <param name="pdfWrapper">The wrapper class of <see cref="iText"/> operations.</param>
        /// <param name="systemIOWrapper">The wrapper class of <see cref="System.IO"/> operations.</param>
        /// <param name="systemDrawingWrapper">The wrapper class of <see cref="System.Drawing"/> operations.</param>
        public PdfAdapter(string pdfFileName, IPdfWrapper pdfWrapper, ISystemIOWrapper systemIOWrapper, ISystemDrawingWrapper systemDrawingWrapper)
        {
            this.pdfWrapper = pdfWrapper;
            this.systemIOWrapper = systemIOWrapper;
            this.systemDrawingWrapper = systemDrawingWrapper;

            using var writer = this.pdfWrapper.PdfWriter.FromFilename(pdfFileName);
            this.pdfDocument = this.pdfWrapper.PdfDocument.FromPdfWriter(writer);
            this.document = this.pdfWrapper.Document.FromPdfDocument(this.pdfDocument);

            // set margins to 0
            this.document.SetMargins(0, 0, 0, 0);
        }

        /// <inheritdoc/>
        public void AddPageWithImage(string imageFilename)
        {
            IImage img = this.pdfWrapper.Image.FromImageData(this.pdfWrapper.ImageDataFactory.Create(imageFilename));
            this.GetImageDimension(imageFilename, out int width, out int height);

            // 1px = 0.75pt
            this.pdfDocument.SetDefaultPageSize(this.pdfWrapper.PageSize.FromWidthAndHeight(width * .75f, height * .75f));
            if (this.isFirstPage)
            {
                this.isFirstPage = false;
            }
            else
            {
                this.document.Add(this.pdfWrapper.AreaBreak.FromAreaBreakType(AreaBreakType.NEXT_PAGE));
            }

            this.document.Add(img);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.document.Close();
            this.pdfDocument.Close();
        }

        /// <summary>
        /// Gets image dimension of an image file.
        /// </summary>
        /// <param name="filename">The fileName of the image.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        private void GetImageDimension(string filename, out int width, out int height)
        {
            using var fileStream = this.systemIOWrapper.FileStream.CreateFileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var img = this.systemDrawingWrapper.Image.FromStream(fileStream, false, false);
            (width, height) = (img.Width, img.Height);
        }
    }
}
