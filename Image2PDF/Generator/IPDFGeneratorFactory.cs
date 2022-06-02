using System.Collections.Generic;

namespace Image2PDF.PDFGenerator
{
    public interface IPDFGeneratorFactory
    {
        /// <summary>
        /// Creates a PDF generator from image files.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        /// <returns>A generator instance.</returns>
        IPDFGenerator CreateFromFiles(IEnumerable<string> files);
    }
}