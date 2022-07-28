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
    public class PdfAdapter : IDisposable, IPdfAdapter
    {
        /// <summary>
        /// The wrapper class of <see cref="iText"/> operations.
        /// </summary>
        private readonly IPdfWrapper wrapper;

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
        private IPdfDocument? pdfDocument;

        /// <summary>
        /// The document.
        /// </summary>
        private IDocument? document;

        /// <summary>
        /// Indicates whether the current page is the first page.
        /// </summary>
        private bool isFirstPage = true;

        /// <summary>
        /// Indicates whether the instance has been disposed.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAdapter"/> class.
        /// </summary>
        public PdfAdapter()
            : this(new PdfWrapper(), new SystemIOWrapper(), new SystemDrawingWrapper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAdapter"/> class.
        /// </summary>
        /// <param name="pdfWrapper">The wrapper class of <see cref="iText"/> operations.</param>
        /// <param name="systemIOWrapper">The wrapper class of <see cref="System.IO"/> operations.</param>
        /// <param name="systemDrawingWrapper">The wrapper class of <see cref="System.Drawing"/> operations.</param>
        public PdfAdapter(IPdfWrapper pdfWrapper, ISystemIOWrapper systemIOWrapper, ISystemDrawingWrapper systemDrawingWrapper)
        {
            this.wrapper = pdfWrapper;
            this.systemIOWrapper = systemIOWrapper;
            this.systemDrawingWrapper = systemDrawingWrapper;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PdfAdapter"/> class.
        /// </summary>
        ~PdfAdapter()
        {
            this.Dispose(false);
        }

        /// <inheritdoc/>
        public void CreatePdfDocumentFromFilename(string pdfFileName)
        {
            using IPdfWriter writer = this.wrapper.PdfWriter.FromFilename(pdfFileName);
            this.pdfDocument = this.wrapper.PdfDocument.FromPdfWriter(writer);
            this.document = this.wrapper.Document.FromPdfDocument(this.pdfDocument);

            // set margins to 0
            this.document.SetMargins(0, 0, 0, 0);
        }

        /// <inheritdoc/>
        public void AddPageWithImage(string imageFilename)
        {
            if (this.pdfDocument == null || this.document == null)
            {
                throw new InvalidOperationException($"{nameof(this.CreatePdfDocumentFromFilename)} has not been called.");
            }

            IImage img = this.wrapper.Image.FromImageData(this.wrapper.ImageDataFactory.Create(imageFilename));
            this.GetImageDimension(imageFilename, out int width, out int height);

            // 1px = 0.75pt
            this.pdfDocument.SetDefaultPageSize(this.wrapper.PageSize.FromWidthAndHeight(width * .75f, height * .75f));
            if (this.isFirstPage)
            {
                this.isFirstPage = false;
            }
            else
            {
                this.document.Add(this.wrapper.AreaBreak.FromAreaBreakType(AreaBreakType.NEXT_PAGE));
            }

            this.document.Add(img);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the instance.
        /// </summary>
        /// <param name="disposing">Whether the call is from <see cref="Dispose()"/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (disposing)
            {
                this.document?.Close();
                this.pdfDocument?.Close();
            }

            this.isDisposed = true;
        }

        /// <summary>
        /// Gets image dimension of an image file.
        /// </summary>
        /// <param name="filename">The fileName of the image.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        private void GetImageDimension(string filename, out int width, out int height)
        {
            using Stream fileStream = this.systemIOWrapper.FileStream.CreateFileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            using ISystemDrawingImage img = this.systemDrawingWrapper.Image.FromStream(fileStream, false, false);
            (width, height) = (img.Width, img.Height);
        }
    }
}
