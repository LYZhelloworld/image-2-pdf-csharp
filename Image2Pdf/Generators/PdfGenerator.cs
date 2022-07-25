// <copyright file="PdfGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Generators
{
    using System;
    using System.Collections.Generic;
    using Image2Pdf.Adapters;

    /// <summary>
    /// The PDF file generator.
    /// </summary>
    public class PdfGenerator : IPdfGenerator
    {
        /// <summary>
        /// The image files to read.
        /// </summary>
        private readonly IEnumerable<string> files;

        /// <summary>
        /// The PDF adapter factory.
        /// </summary>
        private readonly IPdfAdapterFactory pdfAdapterFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfGenerator"/> class.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        public PdfGenerator(IEnumerable<string> files)
            : this(files, new PdfAdapterFactory())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfGenerator"/> class.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        /// <param name="pdfAdapterFactory">The PDF adapter factory.</param>
        public PdfGenerator(IEnumerable<string> files, IPdfAdapterFactory pdfAdapterFactory)
        {
            this.files = files;
            this.pdfAdapterFactory = pdfAdapterFactory;
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
        public void Generate(string target)
        {
            using IPdfAdapter adapter = this.pdfAdapterFactory.CreateAdapter();

            adapter.CreatePdfDocumentFromFilename(target);
            int index = 1;
            foreach (string file in this.files)
            {
                adapter.AddPageWithImage(file);
                this.OnFileProcessedEvent(file, index);
                index++;
            }

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
    }
}
