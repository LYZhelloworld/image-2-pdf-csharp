// <copyright file="MainWindowModelTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Models
{
    using FluentAssertions;
    using Image2Pdf.Generators;
    using Image2Pdf.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests <see cref="MainWindowModel"/>.
    /// </summary>
    [TestClass]
    public class MainWindowModelTest
    {
        /// <summary>
        /// The mock <see cref="IPdfGenerator"/>.
        /// </summary>
        private readonly Mock<IPdfGenerator> pdfGenerator = new();

        /// <summary>
        /// Tests <see cref="MainWindowModel.AddFiles(string[])"/> and <see cref="MainWindowModel.Clear"/>.
        /// </summary>
        [TestMethod]
        public void TestAddFilesAndClear()
        {
            MainWindowModel model = new(this.pdfGenerator.Object);
            model.AddFiles("1.jpg", "2.jpg");
            IEnumerable<string> list = model.ItemSource;
            list.Should().HaveCount(2);
            list.Should().BeEquivalentTo(new string[] { "1.jpg", "2.jpg" });

            model.Clear();
            list.Should().BeEmpty();
        }

        /// <summary>
        /// Tests the following methods:
        /// <list type="bullet">
        ///     <item><see cref="MainWindowModel.CanMoveUp(int)"/></item>
        ///     <item><see cref="MainWindowModel.MoveUp(int)"/></item>
        ///     <item><see cref="MainWindowModel.CanMoveDown(int)"/></item>
        ///     <item><see cref="MainWindowModel.MoveDown(int)"/></item>
        ///     <item><see cref="MainWindowModel.CanRemove(int)"/></item>
        ///     <item><see cref="MainWindowModel.Remove(int)"/></item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void TestMoveAndRemove()
        {
            MainWindowModel model = new(this.pdfGenerator.Object);
            model.AddFiles("1.jpg", "2.jpg", "3.jpg");

            model.CanMoveUp(-1).Should().BeFalse();
            model.CanMoveUp(0).Should().BeFalse();
            model.CanMoveUp(1).Should().BeTrue();
            model.MoveUp(1);
            model.ItemSource.Should().BeEquivalentTo(new List<string>() { "2.jpg", "1.jpg", "3.jpg" });

            model.CanMoveDown(-1).Should().BeFalse();
            model.CanMoveDown(2).Should().BeFalse();
            model.CanMoveDown(0).Should().BeTrue();
            model.MoveDown(0);
            model.ItemSource.Should().BeEquivalentTo(new List<string>() { "1.jpg", "2.jpg", "3.jpg" });

            model.CanRemove(-1).Should().BeFalse();
            model.CanRemove(0).Should().BeTrue();
            while (model.CanRemove(0))
            {
                model.Remove(0);
            }

            model.ItemSource.Should().BeEmpty();
        }

        /// <summary>
        /// Tests <see cref="MainWindowModel.CanGenerate"/> and <see cref="MainWindowModel.Generate(string)"/>.
        /// </summary>
        /// <param name="testEventHandlers">Whether to test event handlers. Set it to <c>false</c> to skip.</param>
        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void TestGenerate(bool testEventHandlers)
        {
            string[] testImageFiles = new string[]
            {
                "1.jpg",
                "2.jpg",
                "3.jpg",
            };
            const string testPdfFilename = "test.pdf";

            this.pdfGenerator.Setup(x => x.Generate(It.IsAny<IEnumerable<string>>(), It.IsAny<string>()))
                .Callback<IEnumerable<string>, string>((files, target) =>
                {
                    files.Should().BeEquivalentTo(testImageFiles);

                    foreach (var item in files.Select((filename, i) => (filename, i)))
                    {
                        this.pdfGenerator.Raise(x => x.FileProcessedEvent += null, new FileProcessedEventArgs(item.filename, item.i));
                    }

                    this.pdfGenerator.Raise(x => x.PdfGenerationCompletedEvent += null, new PdfGenerationCompletedEventArgs(target));
                });

            List<FileProcessedEventArgs> fileProcessedEventTriggered = new();
            List<PdfGenerationCompletedEventArgs> pdfGenerationCompletedEventTriggered = new();

            MainWindowModel model = new(this.pdfGenerator.Object);
            if (testEventHandlers)
            {
                model.FileProcessedEvent += (_, args) => fileProcessedEventTriggered.Add(args);
                model.PdfGenerationCompletedEvent += (_, args) => pdfGenerationCompletedEventTriggered.Add(args);
            }

            model.CanGenerate().Should().BeFalse();
            model.AddFiles(testImageFiles);
            model.CanGenerate().Should().BeTrue();
            model.Generate(testPdfFilename).Wait();

            if (testEventHandlers)
            {
                fileProcessedEventTriggered.Should().BeEquivalentTo(testImageFiles.Select((filename, i) => new FileProcessedEventArgs(filename, i)));
                pdfGenerationCompletedEventTriggered.Should().BeEquivalentTo(new PdfGenerationCompletedEventArgs[] { new(testPdfFilename) });
            }
        }
    }
}
