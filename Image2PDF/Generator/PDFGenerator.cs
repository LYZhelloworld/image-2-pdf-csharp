using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Collections.Generic;

namespace Image2PDF.PDFGenerator
{
    internal class PDFGenerator : IPDFGenerator
    {
        public event IPDFGenerator.FileProcessedEventHandler? FileProcessedEvent;
        public event IPDFGenerator.PDFGenerationCompletedEventHandler? PDFGenerationCompletedEvent;

        private readonly IEnumerable<string> files;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        public PDFGenerator(IEnumerable<string> files)
        {
            this.files = files;
        }

        public void Generate(string target)
        {
            PdfDocument pdfDoc = new(new PdfWriter(target));
            Document doc = new(pdfDoc);

            int index = 1;
            foreach (string file in files)
            {
                Image img = new Image(ImageDataFactory.Create(file));
                // add image to PDF
                doc.Add(img);
                // trigger event
                OnFileProcessedEvent(file, index);
                index++;
            }

            // completed
            pdfDoc.Close();
            OnPDFGenerationCompletedEvent(target);
        }

        /// <summary>
        /// Triggers the event when a file has been processed.
        /// </summary>
        /// <param name="filename">The filename that has been processed.</param>
        /// <param name="progress">ID of the file processed, staring from 1.</param>
        /// <param name="total">Total number of files.</param>
        protected virtual void OnFileProcessedEvent(string filename, int progress)
        {
            FileProcessedEvent?.Invoke(this, new FileProcessedEventArgs
            {
                Filename = filename,
                Progress = progress,
            });
        }

        protected virtual void OnPDFGenerationCompletedEvent(string pdfFilename)
        {
            PDFGenerationCompletedEvent?.Invoke(this, new PDFGenerationCompletedEventArgs
            {
                PDFFilename = pdfFilename,
            });
        }
    }
}
