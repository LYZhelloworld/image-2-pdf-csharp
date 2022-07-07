using System.Diagnostics.CodeAnalysis;
using Image2Pdf.Adapters;
using Image2Pdf.Wrappers;
using iText.Layout.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Image2PdfTest.Adapter;

/// <summary>
/// Tests <see cref="PdfAdapter"/>.
/// </summary>
[TestClass]
[ExcludeFromCodeCoverage]
public class PdfAdapterTest
{
    /// <summary>
    /// The mocked <see cref="IPdfWrapper"/>.
    /// </summary>
    private readonly Mock<IPdfWrapper> _wrapper = new();

    /// <summary>
    /// The mocked <see cref="ISystemIOWrapper"/>.
    /// </summary>
    private readonly Mock<ISystemIOWrapper> _systemIOWrapper = new();

    /// <summary>
    /// The mocked <see cref="ISystemDrawingWrapper"/>.
    /// </summary>
    private readonly Mock<ISystemDrawingWrapper> _systemDrawingWrapper = new();

    /// <summary>
    /// Creates a new <see cref="PdfAdapter"/> object.
    /// </summary>
    /// <returns>A new <see cref="PdfAdapter"/> object</returns>
    private PdfAdapter CreateAdapter()
    {
        return new PdfAdapter(_wrapper.Object, _systemIOWrapper.Object, _systemDrawingWrapper.Object);
    }

    /// <summary>
    /// Tests <see cref="PdfAdapter.CreatePdfDocumentFromFilename(string)"/>.
    /// </summary>
    [TestMethod]
    public void TestCreatePdfDocumentFromFilename()
    {
        var document = new Mock<IDocument>();

        _wrapper.Setup(x => x.PdfWriter.FromFilename("test.pdf")).Returns(Mock.Of<IPdfWriter>());
        _wrapper.Setup(x => x.PdfDocument.FromPdfWriter(It.IsAny<IPdfWriter>())).Returns(Mock.Of<IPdfDocument>());
        _wrapper.Setup(x => x.Document.FromPdfDocument(It.IsAny<IPdfDocument>())).Returns(document.Object);

        using PdfAdapter adapter = CreateAdapter();
        adapter.CreatePdfDocumentFromFilename("test.pdf");

        document.Verify(x => x.SetMargins(0, 0, 0, 0), Times.Once);
    }

    /// <summary>
    /// Tests <see cref="PdfAdapter.AddPageWithImage(string)"/>.
    /// </summary>
    [TestMethod]
    public void TestAddPageWithImage()
    {
        var document = new Mock<IDocument>();
        var systemDrawingImage = new Mock<ISystemDrawingImage>();

        _wrapper.Setup(x => x.PdfWriter.FromFilename("test.pdf")).Returns(Mock.Of<IPdfWriter>());
        _wrapper.Setup(x => x.PdfDocument.FromPdfWriter(It.IsAny<IPdfWriter>())).Returns(Mock.Of<IPdfDocument>());
        _wrapper.Setup(x => x.Document.FromPdfDocument(It.IsAny<IPdfDocument>())).Returns(document.Object);
        _wrapper.Setup(x => x.ImageDataFactory.Create(It.IsAny<string>())).Returns(Mock.Of<IImageData>());
        _wrapper.Setup(x => x.Image.FromImageData(It.IsAny<IImageData>())).Returns(Mock.Of<IImage>());
        _wrapper.Setup(x => x.PageSize.FromWidthAndHeight(800 * 0.75f, 600 * 0.75f)).Returns(Mock.Of<IPageSize>());
        _wrapper.Setup(x => x.AreaBreak.FromAreaBreakType(AreaBreakType.NEXT_PAGE)).Returns(Mock.Of<IAreaBreak>());

        _systemIOWrapper.Setup(x => x.FileStream.CreateFileStream(It.IsAny<string>(), It.IsAny<FileMode>(), It.IsAny<FileAccess>(), It.IsAny<FileShare>())).Returns(Mock.Of<Stream>());

        systemDrawingImage.Setup(x => x.Width).Returns(800);
        systemDrawingImage.Setup(x => x.Height).Returns(600);

        _systemDrawingWrapper.Setup(x => x.Image.FromStream(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(systemDrawingImage.Object);

        using PdfAdapter adapter = CreateAdapter();
        adapter.CreatePdfDocumentFromFilename("test.pdf");

        // First page.
        adapter.AddPageWithImage("01.jpg");
        document.Verify(x => x.Add(It.IsAny<IImage>()), Times.Once);

        // Second page.
        adapter.AddPageWithImage("02.jpg");
        document.Verify(x => x.Add(It.IsAny<IImage>()), Times.Exactly(2));
        document.Verify(x => x.Add(It.IsAny<IAreaBreak>()), Times.Once);
    }
}
