namespace Image2PDF.PDFGenerator
{
    using System.Collections.Generic;

    public class PDFGeneratorFactory : IPDFGeneratorFactory
    {
        public IPDFGenerator CreateFromFiles(IEnumerable<string> files)
        {
            return new PDFGenerator(files);
        }
    }
}
