using System.Collections.Generic;

namespace Image2PDF.PDFGenerator
{
    public class PDFGeneratorFactory : IPDFGeneratorFactory
    {
        public IPDFGenerator CreateFromFiles(IEnumerable<string> files)
        {
            return new PDFGenerator(files);
        }
    }
}
