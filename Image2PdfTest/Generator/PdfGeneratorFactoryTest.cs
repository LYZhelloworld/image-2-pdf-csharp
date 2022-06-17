namespace Image2PdfTest.Generator
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Image2Pdf.Generator;
    using Image2Pdf.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests of <see cref="PdfGeneratorFactory"/>.
    /// </summary>
    [TestClass]
    public class PdfGeneratorFactoryTest
    {
        /// <summary>
        /// Tests <see cref="PdfGeneratorFactory.PdfGeneratorFactory"/>.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            PdfGeneratorFactory factory = new();
            factory.Should().NotBeNull();
        }

        /// <summary>
        /// Tests <see cref="PdfGeneratorFactory.AddFiles(IEnumerable{string})"/> and <see cref="PdfGeneratorFactory.Build"/>.
        /// </summary>
        [TestMethod]
        public void TestBuild()
        {
            PdfGeneratorFactory factory = new();
            factory.AddFiles(new List<string>());
            IPdfGenerator generator = factory.Build();
            generator.Should().NotBeNull();
        }
    }
}
