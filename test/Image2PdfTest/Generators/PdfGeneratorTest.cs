// <copyright file="PdfGeneratorTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Generators
{
    using FluentAssertions;
    using Image2Pdf.Generators;
    using Image2Pdf.Wrappers.IText;
    using Image2Pdf.Wrappers.SystemDrawing;
    using Image2Pdf.Wrappers.SystemIO;
    using iText.Layout.Properties;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests <see cref="PdfGenerator"/>.
    /// </summary>
    [TestClass]
    public class PdfGeneratorTest
    {
        /// <summary>
        /// Test data of PDF filename.
        /// </summary>
        private const string TestPdfTarget = "target.pdf";

        /// <summary>
        /// Tests data of image file lists.
        /// </summary>
        private static readonly List<string> TestImageFileList = new()
        {
            "test1.jpg",
            "test2.jpg",
            "test3.jpg",
        };

        /// <summary>
        /// The mocked <see cref="IPdfWrapper"/>.
        /// </summary>
        private readonly Mock<IPdfWrapper> pdfWrapper = new();

        /// <summary>
        /// The mocked <see cref="ISystemIOWrapper"/>.
        /// </summary>
        private readonly Mock<ISystemIOWrapper> systemIOWrapper = new();

        /// <summary>
        /// The mocked <see cref="ISystemDrawingWrapper"/>.
        /// </summary>
        private readonly Mock<ISystemDrawingWrapper> systemDrawingWrapper = new();

        /// <summary>
        /// Tests <see cref="PdfGenerator.Generate(IEnumerable{string}, string)"/>.
        /// </summary>
        /// <param name="testEventHandler">A value indicating whether to test event handlers.</param>
        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void TestGenerate(bool testEventHandler)
        {
            var document = new Mock<IDocument>();
            var systemDrawingImage = new Mock<ISystemDrawingImage>();

            this.pdfWrapper.Setup(x => x.PdfWriter.CreateInstance("test.pdf")).Returns(Mock.Of<IPdfWriter>());
            this.pdfWrapper.Setup(x => x.PdfDocument.CreateInstance(It.IsAny<IPdfWriter>())).Returns(Mock.Of<IPdfDocument>());
            this.pdfWrapper.Setup(x => x.Document.CreateInstance(It.IsAny<IPdfDocument>())).Returns(document.Object);
            this.pdfWrapper.Setup(x => x.ImageDataFactory.Create(It.IsAny<string>())).Returns(Mock.Of<IImageData>());
            this.pdfWrapper.Setup(x => x.Image.CreateInstance(It.IsAny<IImageData>())).Returns(Mock.Of<IImage>());
            this.pdfWrapper.Setup(x => x.PageSize.CreateInstance(800 * 0.75f, 600 * 0.75f)).Returns(Mock.Of<IPageSize>());
            this.pdfWrapper.Setup(x => x.AreaBreak.CreateInstance(AreaBreakType.NEXT_PAGE)).Returns(Mock.Of<IAreaBreak>());

            this.systemIOWrapper.Setup(x => x.FileStream.CreateInstance(It.IsAny<string>(), It.IsAny<FileMode>(), It.IsAny<FileAccess>(), It.IsAny<FileShare>())).Returns(Mock.Of<Stream>());

            systemDrawingImage.Setup(x => x.Width).Returns(800);
            systemDrawingImage.Setup(x => x.Height).Returns(600);

            this.systemDrawingWrapper.Setup(x => x.Image.CreateInstance(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(systemDrawingImage.Object);

            var generator = new PdfGenerator(this.pdfWrapper.Object, this.systemIOWrapper.Object, this.systemDrawingWrapper.Object);

            bool fileProcessedEventTriggerred = false;
            bool pdfGenerationCompletedEventTriggered = false;
            if (testEventHandler)
            {
                generator.FileProcessedEvent += (sender, args) =>
                {
                    fileProcessedEventTriggerred = true;
                    args.Filename.Should().BeOneOf(TestImageFileList);
                    args.Progress.Should().Be(TestImageFileList.IndexOf(args.Filename) + 1);
                };
                generator.PdfGenerationCompletedEvent += (sender, args) =>
                {
                    pdfGenerationCompletedEventTriggered = true;
                    args.PdfFilename.Should().Be(TestPdfTarget);
                };
            }

            generator.Generate(TestImageFileList, TestPdfTarget);

            document.Verify(x => x.Add(It.IsAny<IImage>()), Times.Exactly(TestImageFileList.Count));
            document.Verify(x => x.Add(It.IsAny<IAreaBreak>()), Times.Exactly(TestImageFileList.Count - 1));

            if (testEventHandler)
            {
                fileProcessedEventTriggerred.Should().BeTrue();
                pdfGenerationCompletedEventTriggered.Should().BeTrue();
            }
        }

        /// <summary>
        /// Tests <see cref="PdfGenerator.Generate(IEnumerable{string}, string)"/> with null image file list.
        /// </summary>
        [TestMethod]
        public void TestGenerateWithNullFiles()
        {
            var generator = new PdfGenerator(this.pdfWrapper.Object, this.systemIOWrapper.Object, this.systemDrawingWrapper.Object);
            Action a = () => generator.Generate(null!, string.Empty);
            a.Should().Throw<ArgumentNullException>();
        }
    }
}
