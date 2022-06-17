namespace Image2Pdf.Generator
{
    using System.Collections.Generic;
    using System.IO;
    using Image2Pdf.Interface;
    using iText.IO.Image;
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;

    /// <summary>
    /// The PDF file generator.
    /// </summary>
    public class PdfGenerator : IPdfGenerator
    {
        #region Fields

        /// <summary>
        /// The image files to read.
        /// </summary>
        private readonly IEnumerable<string> files;

        #endregion

        #region Events

        /// <summary>
        /// The event that a file has been processed.
        /// </summary>
        public event IPdfGenerator.FileProcessedEventHandler? FileProcessedEvent;

        /// <summary>
        /// The event that the PDF has been generated.
        /// </summary>
        public event IPdfGenerator.PdfGenerationCompletedEventHandler? PdfGenerationCompletedEvent;

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
        public PdfGenerator(IEnumerable<string> files)
        {
            this.files = files;
        }

        #endregion

        #region Methods
        #region Public Methods

        /// <summary>
        /// Generates PDF file.
        /// </summary>
        /// <param name="target">The PDF file location.</param>
        public void Generate(string target)
        {
            using (PdfDocument? pdfDoc = new(new PdfWriter(target)))
            {
                using Document? doc = new(pdfDoc);
                // set margins to 0
                doc.SetMargins(0, 0, 0, 0);
                int index = 1;
                foreach (string file in this.files)
                {
                    Image img = new(ImageDataFactory.Create(file));
                    // add image to PDF
                    GetImageDimension(file, out int width, out int height);
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
            this.OnPdfGenerationCompletedEvent(target);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets image dimension of an image file.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        private static void GetImageDimension(string filename, out int width, out int height)
        {
            using FileStream? fileStream = new(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            using System.Drawing.Image? img = System.Drawing.Image.FromStream(fileStream, false, false);
            (width, height) = (img.Width, img.Height);
        }

        #endregion
        #endregion
    }
}
