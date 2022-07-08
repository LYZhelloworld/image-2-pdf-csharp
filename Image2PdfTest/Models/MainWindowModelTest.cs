using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Image2Pdf.Generators;
using Image2Pdf.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Image2PdfTest.Models;

/// <summary>
/// Tests <see cref="MainWindowModel"/>.
/// </summary>
[TestClass]
[ExcludeFromCodeCoverage]
public class MainWindowModelTest
{
    /// <summary>
    /// The mock <see cref="IPdfGeneratorFactory"/>.
    /// </summary>
    private Mock<IPdfGeneratorFactory> _pdfGeneratorFactory = default!;

    /// <summary>
    /// The mock <see cref="IPdfGenerator"/>.
    /// </summary>
    private Mock<IPdfGenerator> _pdfGenerator = default!;

    /// <summary>
    /// Initializes tests.
    /// </summary>
    [TestInitialize]
    public void Initialize()
    {
        _pdfGeneratorFactory = new();
        _pdfGenerator = new();
        _pdfGeneratorFactory.Setup(x => x.Build()).Returns(_pdfGenerator.Object);
    }

    /// <summary>
    /// Tests <see cref="MainWindowModel.MainWindowModel"/>.
    /// </summary>
    [TestMethod]
    public void TestConstructor()
    {
        var model = new MainWindowModel();
        model.Should().NotBeNull();
    }

    /// <summary>
    /// Tests <see cref="MainWindowModel.AddFiles(string[])"/> and <see cref="MainWindowModel.Clear"/>.
    /// </summary>
    [TestMethod]
    public void TestAddFilesAndClear()
    {
        MainWindowModel model = new(_pdfGeneratorFactory.Object);
        model.AddFiles("1.jpg", "2.jpg");
        IEnumerable<string> list = model.ItemSource;
        list.Should().HaveCount(2);
        list.Should().BeEquivalentTo(new List<string>()
        {
            "1.jpg",
            "2.jpg",
        });

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
        MainWindowModel model = new(_pdfGeneratorFactory.Object);
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
            "1.jpg", "2.jpg", "3.jpg"
        };
        const string testPdfFilename = "test.pdf";

        IEnumerable<string>? filenames = null;
        _pdfGeneratorFactory.Setup(x => x.AddFiles(It.IsAny<IEnumerable<string>>()))
                            .Callback<IEnumerable<string>>(x => filenames = x)
                            .Returns(_pdfGeneratorFactory.Object);
        _pdfGenerator.Setup(x => x.Generate(It.IsAny<string>()))
            .Callback<string>(pdfFilename =>
            {
                filenames?.Select((filename, i) =>
                {
                    return (filename, i);
                })
                .ToList()
                .ForEach(item => _pdfGenerator.Raise(x => x.FileProcessedEvent += null, new FileProcessedEventArgs(item.filename, item.i)));
                _pdfGenerator.Raise(x => x.PdfGenerationCompletedEvent += null, new PdfGenerationCompletedEventArgs(pdfFilename));
            });

        List<FileProcessedEventArgs> fileProcessedEventTriggered = new();
        List<PdfGenerationCompletedEventArgs> pdfGenerationCompletedEventTriggered = new();

        MainWindowModel model = new(_pdfGeneratorFactory.Object);
        if (testEventHandlers)
        {
            model.FileProcessedEvent += (_, args) => fileProcessedEventTriggered.Add(args);
            model.PdfGenerationCompletedEvent += (_, args) => pdfGenerationCompletedEventTriggered.Add(args);
        }

        model.CanGenerate().Should().BeFalse();
        model.AddFiles(testImageFiles);
        model.CanGenerate().Should().BeTrue();
        model.Generate(testPdfFilename).Wait();

        filenames.Should().NotBeNull();
        filenames.Should().BeEquivalentTo(testImageFiles);

        if (testEventHandlers)
        {
            fileProcessedEventTriggered.Should().BeEquivalentTo(testImageFiles.Select((filename, i) => new FileProcessedEventArgs(filename, i)));
            pdfGenerationCompletedEventTriggered.Should().BeEquivalentTo(new PdfGenerationCompletedEventArgs[] { new(testPdfFilename) });
        }
    }
}
