namespace Image2PDF.PDFGenerator
{
    using System.Collections.Generic;
    using System.IO;
    using iText.IO.Image;
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;
    public class PDFGenerator : IPDFGenerator
    {
        private readonly IEnumerable<string> files;

        #region Events
        public event IPDFGenerator.FileProcessedEventHandler? FileProcessedEvent;
        public event IPDFGenerator.PDFGenerationCompletedEventHandler? PDFGenerationCompletedEvent;

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

        /// <summary>
        /// Triggers the event when the PDF has been created.
        /// </summary>
        /// <param name="pdfFilename">The PDF filename.</param>
        protected virtual void OnPDFGenerationCompletedEvent(string pdfFilename)
        {
            PDFGenerationCompletedEvent?.Invoke(this, new PDFGenerationCompletedEventArgs
            {
                PDFFilename = pdfFilename,
            });
        }
        #endregion

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
            using (PdfDocument? pdfDoc = new PdfDocument(new PdfWriter(target)))
            {
                using Document? doc = new Document(pdfDoc);
                // set margins to 0
                doc.SetMargins(0, 0, 0, 0);
                int index = 1;
                foreach (string file in this.files)
                {
                    Image img = new Image(ImageDataFactory.Create(file));
                    // add image to PDF
                    this.getImageDimension(file, out int width, out int height);
                    // 1px = 0.75pt
                    pdfDoc.SetDefaultPageSize(new PageSize(width * .75f, height * .75f));
                    if (index > 1) doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    doc.Add(img);
                    // trigger event
                    this.OnFileProcessedEvent(file, index);
                    index++;
                }
            }
            // completed
            this.OnPDFGenerationCompletedEvent(target);
        }

        /// <summary>
        /// Gets image dimension of an image file.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        private void getImageDimension(string filename, out int width, out int height)
        {
            using FileStream? fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            using System.Drawing.Image? img = System.Drawing.Image.FromStream(fileStream, false, false);
            (width, height) = (img.Width, img.Height);
        }
    }
}
