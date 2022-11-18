// <copyright file="PdfAdapterTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Adapters
{
    using FluentAssertions;
    using Image2Pdf.Adapters;
    using Image2Pdf.Wrappers;
    using iText.Layout.Properties;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests <see cref="PdfAdapter"/>.
    /// </summary>
    [TestClass]
    public class PdfAdapterTest
    {
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
        /// Tests <see cref="PdfAdapter.AddPageWithImage(string)"/>.
        /// </summary>
        [TestMethod]
        public void TestAddPageWithImage()
        {
            var document = new Mock<IDocument>();
            var systemDrawingImage = new Mock<ISystemDrawingImage>();

            this.pdfWrapper.Setup(x => x.PdfWriter.FromFilename("test.pdf")).Returns(Mock.Of<IPdfWriter>());
            this.pdfWrapper.Setup(x => x.PdfDocument.FromPdfWriter(It.IsAny<IPdfWriter>())).Returns(Mock.Of<IPdfDocument>());
            this.pdfWrapper.Setup(x => x.Document.FromPdfDocument(It.IsAny<IPdfDocument>())).Returns(document.Object);
            this.pdfWrapper.Setup(x => x.ImageDataFactory.Create(It.IsAny<string>())).Returns(Mock.Of<IImageData>());
            this.pdfWrapper.Setup(x => x.Image.FromImageData(It.IsAny<IImageData>())).Returns(Mock.Of<IImage>());
            this.pdfWrapper.Setup(x => x.PageSize.FromWidthAndHeight(800 * 0.75f, 600 * 0.75f)).Returns(Mock.Of<IPageSize>());
            this.pdfWrapper.Setup(x => x.AreaBreak.FromAreaBreakType(AreaBreakType.NEXT_PAGE)).Returns(Mock.Of<IAreaBreak>());

            this.systemIOWrapper.Setup(x => x.FileStream.CreateFileStream(It.IsAny<string>(), It.IsAny<FileMode>(), It.IsAny<FileAccess>(), It.IsAny<FileShare>())).Returns(Mock.Of<Stream>());

            systemDrawingImage.Setup(x => x.Width).Returns(800);
            systemDrawingImage.Setup(x => x.Height).Returns(600);

            this.systemDrawingWrapper.Setup(x => x.Image.FromStream(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(systemDrawingImage.Object);

            using PdfAdapter adapter = this.CreateInstance();

            // First page.
            adapter.AddPageWithImage("01.jpg");
            document.Verify(x => x.Add(It.IsAny<IImage>()), Times.Once);

            // Second page.
            adapter.AddPageWithImage("02.jpg");
            document.Verify(x => x.Add(It.IsAny<IImage>()), Times.Exactly(2));
            document.Verify(x => x.Add(It.IsAny<IAreaBreak>()), Times.Once);
        }

        /// <summary>
        /// Creates a new <see cref="PdfAdapter"/> object.
        /// </summary>
        /// <returns>A new <see cref="PdfAdapter"/> object.</returns>
        private PdfAdapter CreateInstance()
        {
            return new PdfAdapter("test.pdf", this.pdfWrapper.Object, this.systemIOWrapper.Object, this.systemDrawingWrapper.Object);
        }
    }
}
