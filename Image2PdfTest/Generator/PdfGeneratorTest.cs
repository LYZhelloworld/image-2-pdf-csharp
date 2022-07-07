using FluentAssertions;
using Image2Pdf.Adapters;
using Image2Pdf.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Image2PdfTest.Generator;

/// <summary>
/// Tests <see cref="PdfGenerator"/>.
/// </summary>
[TestClass]
public class PdfGeneratorTest
{
    /// <summary>
    /// Tests data of image file lists.
    /// </summary>
    private static readonly List<string> s_testImageFileList = new()
    {
        "test1",
        "test2",
        "test3",
    };

    /// <summary>
    /// Test data of PDF filename.
    /// </summary>
    private const string TestPdfTarget = "test_pdf_target";

    /// <summary>
    /// Tests <see cref="PdfGenerator(IEnumerable{string})"/>.
    /// </summary>
    [TestMethod]
    public void TestConstructor()
    {
        PdfGenerator generator = new(new List<string>());
        generator.Should().NotBeNull();
    }

    /// <summary>
    /// Tests <see cref="PdfGenerator.Generate(string)"/> without event handlers.
    /// </summary>
    [TestMethod]
    public void TestGenerateNoEventHandlers()
    {
        Mock<IPdfAdapterFactory> factory = new();
        Mock<IPdfAdapter> adapter = new();
        factory.Setup(x => x.CreateAdapter()).Returns(adapter.Object);

        PdfGenerator generator = new(s_testImageFileList, factory.Object);
        generator.Generate(TestPdfTarget);

        adapter.Verify(x => x.CreatePdfDocumentFromFilename(TestPdfTarget));
        s_testImageFileList.ForEach(i => adapter.Verify(x => x.AddPageWithImage(i)));
        adapter.Verify(x => x.Dispose());
    }

    /// <summary>
    /// Tests <see cref="PdfGenerator.Generate(string)"/> with event handlers.
    /// </summary>
    [TestMethod]
    public void TestGenerateWithEventHandlers()
    {
        Mock<IPdfAdapterFactory> factory = new();
        Mock<IPdfAdapter> adapter = new();
        factory.Setup(x => x.CreateAdapter()).Returns(adapter.Object);
        bool fileProcessedEventTriggerred = false;
        bool pdfGenerationCompletedEventTriggered = false;

        PdfGenerator generator = new(s_testImageFileList, factory.Object);
        generator.FileProcessedEvent += (sender, args) =>
        {
            fileProcessedEventTriggerred = true;
            args.Filename.Should().BeOneOf(s_testImageFileList);
            args.Progress.Should().Be(s_testImageFileList.IndexOf(args.Filename) + 1);
        };
        generator.PdfGenerationCompletedEvent += (sender, args) =>
        {
            pdfGenerationCompletedEventTriggered = true;
            args.PdfFilename.Should().Be(TestPdfTarget);
        };
        generator.Generate(TestPdfTarget);

        adapter.Verify(x => x.CreatePdfDocumentFromFilename(TestPdfTarget));
        s_testImageFileList.ForEach(i => adapter.Verify(x => x.AddPageWithImage(i)));
        adapter.Verify(x => x.Dispose());
        fileProcessedEventTriggerred.Should().BeTrue();
        pdfGenerationCompletedEventTriggered.Should().BeTrue();
    }
}
