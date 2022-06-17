namespace Image2PDF.PDFGenerator
{
    using System.Collections.Generic;
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