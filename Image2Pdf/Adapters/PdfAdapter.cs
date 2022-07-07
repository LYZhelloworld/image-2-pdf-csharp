using System;
using System.Diagnostics;
using System.IO;
using Image2Pdf.Wrappers;
using iText.Layout.Properties;

namespace Image2Pdf.Adapters;

/// <summary>
/// The adapter of iText PDF generator.
/// </summary>
public sealed class PdfAdapter : IDisposable, IPdfAdapter
{
    /// <summary>
    /// The PDF document.
    /// </summary>
    private IPdfDocument? _pdfDocument;

    /// <summary>
    /// The document.
    /// </summary>
    private IDocument? _document;

    /// <summary>
    /// The wrapper class of <see cref="iText"/> operations.
    /// </summary>
    private readonly IPdfWrapper _wrapper;

    /// <summary>
    /// The wrapper class of <see cref="System.IO"/> operations.
    /// </summary>
    private readonly ISystemIOWrapper _systemIOWrapper;

    /// <summary>
    /// The wrapper class of <see cref="System.Drawing"/> operations.
    /// </summary>
    private readonly ISystemDrawingWrapper _systemDrawingWrapper;

    /// <summary>
    /// Indicates whether the current page is the first page.
    /// </summary>
    private bool _isFirstPage = true;

    /// <summary>
    /// The constructor.
    /// </summary>
    public PdfAdapter()
        : this(new PdfWrapper(), new SystemIOWrapper(), new SystemDrawingWrapper())
    {
    }

    /// <summary>
    /// The constructor with all properties.
    /// </summary>
    /// <param name="pdfWrapper">The wrapper class of <see cref="iText"/> operations.</param>
    /// <param name="systemIOWrapper">The wrapper class of <see cref="System.IO"/> operations.</param>
    /// <param name="systemDrawingWrapper">The wrapper class of <see cref="System.Drawing"/> operations.</param>
    public PdfAdapter(IPdfWrapper pdfWrapper, ISystemIOWrapper systemIOWrapper, ISystemDrawingWrapper systemDrawingWrapper)
    {
        _wrapper = pdfWrapper;
        _systemIOWrapper = systemIOWrapper;
        _systemDrawingWrapper = systemDrawingWrapper;
    }

    /// <inheritdoc/>
    public void CreatePdfDocumentFromFilename(string pdfFileName)
    {
        using IPdfWriter writer = _wrapper.PdfWriter.FromFilename(pdfFileName);
        _pdfDocument = _wrapper.PdfDocument.FromPdfWriter(writer);
        _document = _wrapper.Document.FromPdfDocument(_pdfDocument);
        // set margins to 0
        _document.SetMargins(0, 0, 0, 0);
    }

    /// <inheritdoc/>
    public void AddPageWithImage(string imageFilename)
    {
        Debug.Assert(_pdfDocument != null);
        Debug.Assert(_document != null);

        IImage img = _wrapper.Image.FromImageData(_wrapper.ImageDataFactory.Create(imageFilename));
        GetImageDimension(imageFilename, out int width, out int height);
        // 1px = 0.75pt
        _pdfDocument.SetDefaultPageSize(_wrapper.PageSize.FromWidthAndHeight(width * .75f, height * .75f));
        if (!_isFirstPage)
        {
            _document.Add(_wrapper.AreaBreak.FromAreaBreakType(AreaBreakType.NEXT_PAGE));
            _isFirstPage = false;
        }
        _document.Add(img);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_document != null)
        {
            _document.Close();
        }

        if (_pdfDocument != null)
        {
            _pdfDocument.Close();
        }

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Gets image dimension of an image file.
    /// </summary>
    /// <param name="filename">The fileName of the image.</param>
    /// <param name="width">The width of the image.</param>
    /// <param name="height">The height of the image.</param>
    private void GetImageDimension(string filename, out int width, out int height)
    {
        using Stream fileStream = _systemIOWrapper.FileStream.CreateFileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        using ISystemDrawingImage img = _systemDrawingWrapper.Image.FromStream(fileStream, false, false);
        (width, height) = (img.Width, img.Height);
    }
}
