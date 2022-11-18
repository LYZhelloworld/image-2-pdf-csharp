// <copyright file="PdfAdapterFactoryTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Adapters
{
    using FluentAssertions;
    using Image2Pdf.Adapters;
    using Image2Pdf.Wrappers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests <see cref="PdfAdapterFactory"/>.
    /// </summary>
    [TestClass]
    public class PdfAdapterFactoryTest
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
        /// Tests <see cref="PdfAdapterFactory.CreateInstance"/>.
        /// </summary>
        [TestMethod]
        public void TestCreateAdapter()
        {
            this.pdfWrapper.Setup(x => x.PdfWriter).Returns(Mock.Of<IPdfWriterFactory>(x => x.FromFilename("test.pdf") == Mock.Of<IPdfWriter>()));
            this.pdfWrapper.Setup(x => x.PdfDocument).Returns(Mock.Of<IPdfDocumentFactory>(x => x.FromPdfWriter(It.IsAny<IPdfWriter>()) == Mock.Of<IPdfDocument>()));
            this.pdfWrapper.Setup(x => x.Document).Returns(Mock.Of<IDocumentFactory>(x => x.FromPdfDocument(It.IsAny<IPdfDocument>()) == Mock.Of<IDocument>()));

            PdfAdapterFactory factory = new PdfAdapterFactory(this.pdfWrapper.Object, this.systemIOWrapper.Object, this.systemDrawingWrapper.Object);
            IPdfAdapter adapter = factory.CreateInstance("test.pdf");
            adapter.Should().NotBeNull();
        }
    }
}
