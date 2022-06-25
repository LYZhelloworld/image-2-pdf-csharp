namespace Image2Pdf.Adapter
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Image2Pdf.Interface;
    using iText.IO.Image;
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;

    /// <summary>
    /// The adapter of iText PDF generator.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PdfAdapter : IDisposable, IPdfAdapter
    {
        /// <summary>
        /// The PDF document.
        /// </summary>
        private PdfDocument? pdfDocument;

        /// <summary>
        /// The document.
        /// </summary>
        private Document? document;

        /// <summary>
        /// Indicates whether the current page is the first page.
        /// </summary>
        private bool isFirstPage = true;

        /// <summary>
        /// Creates a PDF document from the filename.
        /// </summary>
        /// <param name="pdfFileName">The PDF filename.</param>
        public void CreatePdfDocumentFromFilename(string pdfFileName)
        {
            this.pdfDocument = new PdfDocument(new PdfWriter(pdfFileName));
            this.document = new Document(this.pdfDocument);
            // set margins to 0
            this.document.SetMargins(0, 0, 0, 0);
        }

        /// <summary>
        /// Adds a page with image as background.
        /// </summary>
        /// <param name="imageFilename">The filename of the image.</param>
        public void AddPageWithImage(string imageFilename)
        {
            Debug.Assert(this.pdfDocument != null);
            Debug.Assert(this.document != null);

            Image img = new(ImageDataFactory.Create(imageFilename));
            GetImageDimension(imageFilename, out int width, out int height);
            // 1px = 0.75pt
            this.pdfDocument.SetDefaultPageSize(new PageSize(width * .75f, height * .75f));
            if (!this.isFirstPage)
            {
                this.document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                this.isFirstPage = false;
            }
            this.document.Add(img);
        }

        public void Dispose()
        {
            if (this.pdfDocument != null)
            {
                this.pdfDocument.Close();
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets image dimension of an image imageFilename.
        /// </summary>
        /// <param name="filename">The pdfFileName of the image.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        private static void GetImageDimension(string filename, out int width, out int height)
        {
            using FileStream fileStream = new(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            using System.Drawing.Image img = System.Drawing.Image.FromStream(fileStream, false, false);
            (width, height) = (img.Width, img.Height);
        }
    }
}
