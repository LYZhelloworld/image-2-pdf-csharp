// <copyright file="PdfGeneratorTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Generators
{
    using FluentAssertions;
    using Image2Pdf.Adapters;
    using Image2Pdf.Generators;
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
        private const string TestPdfTarget = "test_pdf_target";

        /// <summary>
        /// Tests data of image file lists.
        /// </summary>
        private static readonly List<string> TestImageFileList = new()
        {
            "test1",
            "test2",
            "test3",
        };

        /// <summary>
        /// Tests <see cref="PdfGenerator.Generate(string)"/> without event handlers.
        /// </summary>
        [TestMethod]
        public void TestGenerateNoEventHandlers()
        {
            Mock<IPdfAdapterFactory> factory = new();
            Mock<IPdfAdapter> adapter = new();
            factory.Setup(x => x.CreateInstance()).Returns(adapter.Object);

            PdfGenerator generator = new(TestImageFileList, factory.Object);
            generator.Generate(TestPdfTarget);

            adapter.Verify(x => x.CreatePdfDocumentFromFilename(TestPdfTarget));
            TestImageFileList.ForEach(i => adapter.Verify(x => x.AddPageWithImage(i)));
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
            factory.Setup(x => x.CreateInstance()).Returns(adapter.Object);
            bool fileProcessedEventTriggerred = false;
            bool pdfGenerationCompletedEventTriggered = false;

            PdfGenerator generator = new(TestImageFileList, factory.Object);
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
            generator.Generate(TestPdfTarget);

            adapter.Verify(x => x.CreatePdfDocumentFromFilename(TestPdfTarget));
            TestImageFileList.ForEach(i => adapter.Verify(x => x.AddPageWithImage(i)));
            adapter.Verify(x => x.Dispose());
            fileProcessedEventTriggerred.Should().BeTrue();
            pdfGenerationCompletedEventTriggered.Should().BeTrue();
        }
    }
}
