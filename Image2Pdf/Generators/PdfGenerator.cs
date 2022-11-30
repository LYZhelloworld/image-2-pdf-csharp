// <copyright file="PdfGenerator.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Image2Pdf.Wrappers;
    using iText.Layout.Properties;

    /// <summary>
    /// The PDF file generator.
    /// </summary>
    public class PdfGenerator : IPdfGenerator
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
        /// Initializes a new instance of the <see cref="PdfGenerator"/> class.
        /// </summary>
        /// <param name="pdfWrapper">The wrapper class of <see cref="iText"/> operations.</param>
        /// <param name="systemIOWrapper">The wrapper class of <see cref="System.IO"/> operations.</param>
        /// <param name="systemDrawingWrapper">The wrapper class of <see cref="System.Drawing"/> operations.</param>
        public PdfGenerator(IPdfWrapper pdfWrapper, ISystemIOWrapper systemIOWrapper, ISystemDrawingWrapper systemDrawingWrapper)
        {
            this.pdfWrapper = pdfWrapper;
            this.systemIOWrapper = systemIOWrapper;
            this.systemDrawingWrapper = systemDrawingWrapper;
        }

        /// <summary>
        /// The event that a file has been processed.
        /// </summary>
        public event EventHandler<FileProcessedEventArgs>? FileProcessedEvent;

        /// <summary>
        /// The event that the PDF has been generated.
        /// </summary>
        public event EventHandler<PdfGenerationCompletedEventArgs>? PdfGenerationCompletedEvent;

        /// <inheritdoc/>
        public void Generate(IEnumerable<string> files, string target)
        {
            if (files == null)
            {
                throw new ArgumentNullException(nameof(files));
            }

            using var pdfWriter = this.pdfWrapper.PdfWriter.FromFilename(target);
            using var pdfDocument = this.pdfWrapper.PdfDocument.FromPdfWriter(pdfWriter);
            using var document = this.pdfWrapper.Document.FromPdfDocument(pdfDocument);

            // Set margins to 0.
            document.SetMargins(0, 0, 0, 0);

            int index = 1;
            foreach (string file in files)
            {
                this.AddPageWithImage(pdfDocument, document, file, index);
                this.OnFileProcessedEvent(file, index);
                index++;
            }

            document.Close();
            pdfDocument.Close();
            this.OnPdfGenerationCompletedEvent(target);
        }

        /// <summary>
        /// Triggers the event when a file has been processed.
        /// </summary>
        /// <param name="filename">The filename that has been processed.</param>
        /// <param name="progress">ID of the file processed, staring from 1.</param>
        protected virtual void OnFileProcessedEvent(string filename, int progress)
        {
            this.FileProcessedEvent?.Invoke(this, new FileProcessedEventArgs(filename, progress));
        }

        /// <summary>
        /// Triggers the event when the PDF has been created.
        /// </summary>
        /// <param name="pdfFilename">The PDF filename.</param>
        protected virtual void OnPdfGenerationCompletedEvent(string pdfFilename)
        {
            this.PdfGenerationCompletedEvent?.Invoke(this, new PdfGenerationCompletedEventArgs(pdfFilename));
        }

        /// <summary>
        /// Adds a page with image as background.
        /// </summary>
        /// <param name="pdfDocument">The PDF document.</param>
        /// <param name="document">The document.</param>
        /// <param name="imageFilename">The filename of the image.</param>
        /// <param name="page">The page number.</param>
        private void AddPageWithImage(IPdfDocument pdfDocument, IDocument document, string imageFilename, int page)
        {
            IImage img = this.pdfWrapper.Image.FromImageData(this.pdfWrapper.ImageDataFactory.Create(imageFilename));
            this.GetImageDimension(imageFilename, out int width, out int height);

            // 1px = 0.75pt.
            pdfDocument.SetDefaultPageSize(this.pdfWrapper.PageSize.FromWidthAndHeight(width * .75f, height * .75f));
            if (page > 1)
            {
                document.Add(this.pdfWrapper.AreaBreak.FromAreaBreakType(AreaBreakType.NEXT_PAGE));
            }

            document.Add(img);
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
