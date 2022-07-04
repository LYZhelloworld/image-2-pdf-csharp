namespace Image2Pdf.Generator
{
    using System;
    using System.Collections.Generic;
    using Image2Pdf.Adapter;
    using Image2Pdf.Interfaces;

    /// <summary>
    /// The PDF file generator.
    /// </summary>
    public class PdfGenerator : IPdfGenerator<FileProcessedEventArgs, PdfGenerationCompletedEventArgs>
    {
        #region Fields

        /// <summary>
        /// The image files to read.
        /// </summary>
        private readonly IEnumerable<string> files;

        /// <summary>
        /// The PDF adapter.
        /// </summary>
        private readonly IPdfAdapterFactory pdfAdapterFactory;

        #endregion

        #region Events

        /// <summary>
        /// The event that a file has been processed.
        /// </summary>
        public event EventHandler<FileProcessedEventArgs>? FileProcessedEvent;

        /// <summary>
        /// The event that the PDF has been generated.
        /// </summary>
        public event EventHandler<PdfGenerationCompletedEventArgs>? PdfGenerationCompletedEvent;

        #endregion

        #region Event Handlers

        /// <summary>
        /// Triggers the event when a file has been processed.
        /// </summary>
        /// <param name="filename">The filename that has been processed.</param>
        /// <param name="progress">ID of the file processed, staring from 1.</param>
        protected virtual void OnFileProcessedEvent(string filename, int progress)
        {
            FileProcessedEvent?.Invoke(this, new FileProcessedEventArgs(filename, progress));
        }

        /// <summary>
        /// Triggers the event when the PDF has been created.
        /// </summary>
        /// <param name="pdfFilename">The PDF filename.</param>
        protected virtual void OnPdfGenerationCompletedEvent(string pdfFilename)
        {
            PdfGenerationCompletedEvent?.Invoke(this, new PdfGenerationCompletedEventArgs(pdfFilename));
        }

        #endregion

        #region Constructors

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        public PdfGenerator(IEnumerable<string> files) : this(files, new PdfAdapterFactory())
        {
        }

        /// <summary>
        /// The constructor with all properties.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="pdfAdapter"></param>
        public PdfGenerator(IEnumerable<string> files, IPdfAdapterFactory pdfAdapterFactory)
        {
            this.files = files;
            this.pdfAdapterFactory = pdfAdapterFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates PDF file.
        /// </summary>
        /// <param name="target">The PDF file location.</param>
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

        #endregion
    }
}
