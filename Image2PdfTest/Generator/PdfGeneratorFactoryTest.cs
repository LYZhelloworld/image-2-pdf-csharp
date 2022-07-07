using FluentAssertions;
using Image2Pdf.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Image2PdfTest.Generator;

/// <summary>
/// Tests <see cref="PdfGeneratorFactory"/>.
/// </summary>
[TestClass]
public class PdfGeneratorFactoryTest
{
    /// <summary>
    /// Tests <see cref="PdfGeneratorFactory.AddFiles(IEnumerable{string})"/> and <see cref="PdfGeneratorFactory.Build"/>.
    /// </summary>
    [TestMethod]
    public void TestBuild()
    {
        PdfGeneratorFactory factory = new();
        factory.AddFiles(new List<string>());
        IPdfGenerator<FileProcessedEventArgs, PdfGenerationCompletedEventArgs> generator = factory.Build();
        generator.Should().NotBeNull();
    }
}
