using System.Collections.Generic;

namespace Image2PDF.PDFGenerator
{
    public static class PDFGeneratorFactory
    {
        /// <summary>
        /// Creates a PDF generator from image files.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        /// <returns>A generator instance.</returns>
        public static IPDFGenerator CreateFromFiles(IEnumerable<string> files)
        {
            return new PDFGenerator(files);
        }
    }
}
