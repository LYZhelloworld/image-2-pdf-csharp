using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Image2PDF
{
    internal class PDFGenerator : IPDFGenerator
    {
        public event IPDFGenerator.FileProcessedEventHandler? FileProcessedEvent;
        public event IPDFGenerator.PDFGenerationCompletedEventHandler? PDFGenerationCompletedEvent;

        private readonly string[] files;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        public PDFGenerator(string[] files)
        {
            this.files = files;
        }

        public void Generate(string target)
        {
            PdfDocument pdfDoc = new(new PdfReader(target));
            Document doc = new(pdfDoc);

            int index = 1;
            int total = files.Length;
            foreach (string file in files)
            {
                Image img = new Image(ImageDataFactory.Create(file));
                // add image to PDF
                doc.Add(img);
                // trigger event
                OnFileProcessedEvent(file, index, total);
                index++;
            }

            // completed
            pdfDoc.Close();
            OnPDFGenerationCompletedEvent();
        }

        /// <summary>
        /// Trigger the event when a file has been processed.
        /// </summary>
        /// <param name="filename">The filename that has been processed.</param>
        /// <param name="progress">ID of the file processed, staring from 1.</param>
        /// <param name="total">Total number of files.</param>
        protected virtual void OnFileProcessedEvent(string filename, int progress, int total)
        {
            FileProcessedEvent?.Invoke(this, new FileProcessedEventArgs
            {
                Filename = filename,
                Progress = progress,
                Total = total,
            });
        }

        protected virtual void OnPDFGenerationCompletedEvent()
        {
            PDFGenerationCompletedEvent?.Invoke(this, new PDFGenerationCompletedEventArgs());
        }
    }
}
