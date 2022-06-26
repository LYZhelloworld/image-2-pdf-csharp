namespace Image2PdfTest.Generator
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Image2Pdf.Generator;
    using Image2Pdf.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests for <see cref="PdfGenerator"/>.
    /// </summary>
    [TestClass]
    public class PdfGeneratorTest
    {
        /// <summary>
        /// Test data of image file lists.
        /// </summary>
        private static readonly List<string> testImageFileList = new()
        {
            "test1",
            "test2",
            "test3",
        };

        /// <summary>
        /// Test data of PDF filename.
        /// </summary>
        private static readonly string testPdfTarget = "test_pdf_target";

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
        public void TestGenerate_NoEventHandlers()
        {
            Mock<IPdfAdapterFactory> factory = new();
            Mock<IPdfAdapter> adapter = new();
            factory.Setup(x => x.CreateAdapter()).Returns(adapter.Object);

            PdfGenerator generator = new(testImageFileList, factory.Object);
            generator.Generate(testPdfTarget);

            adapter.Verify(x => x.CreatePdfDocumentFromFilename(testPdfTarget));
            testImageFileList.ForEach(i => adapter.Verify(x => x.AddPageWithImage(i)));
            adapter.Verify(x => x.Dispose());
        }

        /// <summary>
        /// Tests <see cref="PdfGenerator.Generate(string)"/> with event handlers.
        /// </summary>
        [TestMethod]
        public void TestGenerate_WithEventHandlers()
        {
            Mock<IPdfAdapterFactory> factory = new();
            Mock<IPdfAdapter> adapter = new();
            factory.Setup(x => x.CreateAdapter()).Returns(adapter.Object);
            bool fileProcessedEventTriggerred = false;
            bool pdfGenerationCompletedEventTriggered = false;

            PdfGenerator generator = new(testImageFileList, factory.Object);
            generator.FileProcessedEvent += (sender, args) =>
            {
                fileProcessedEventTriggerred = true;
                args.Filename.Should().BeOneOf(testImageFileList);
                args.Progress.Should().Be(testImageFileList.IndexOf(args.Filename) + 1);
            };
            generator.PdfGenerationCompletedEvent += (sender, args) =>
            {
                pdfGenerationCompletedEventTriggered = true;
                args.PdfFilename.Should().Be(testPdfTarget);
            };
            generator.Generate(testPdfTarget);

            adapter.Verify(x => x.CreatePdfDocumentFromFilename(testPdfTarget));
            testImageFileList.ForEach(i => adapter.Verify(x => x.AddPageWithImage(i)));
            adapter.Verify(x => x.Dispose());
            fileProcessedEventTriggerred.Should().BeTrue();
            pdfGenerationCompletedEventTriggered.Should().BeTrue();
        }
    }
}
