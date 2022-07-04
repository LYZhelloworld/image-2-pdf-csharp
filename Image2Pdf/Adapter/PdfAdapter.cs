using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Image2Pdf.Interfaces;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Image2Pdf.Adapter;

/// <summary>
/// The adapter of iText PDF generator.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class PdfAdapter : IDisposable, IPdfAdapter
{
    /// <summary>
    /// The PDF document.
    /// </summary>
    private PdfDocument? _pdfDocument;

    /// <summary>
    /// The document.
    /// </summary>
    private Document? _document;

    /// <summary>
    /// Indicates whether the current page is the first page.
    /// </summary>
    private bool _isFirstPage = true;

    /// <inheritdoc/>
    public void CreatePdfDocumentFromFilename(string pdfFileName)
    {
        using PdfWriter writer = new(pdfFileName);
        _pdfDocument = new PdfDocument(writer);
        _document = new Document(_pdfDocument);
        // set margins to 0
        _document.SetMargins(0, 0, 0, 0);
    }

    /// <inheritdoc/>
    public void AddPageWithImage(string imageFilename)
    {
        Debug.Assert(_pdfDocument != null);
        Debug.Assert(_document != null);

        Image img = new(ImageDataFactory.Create(imageFilename));
        GetImageDimension(imageFilename, out int width, out int height);
        // 1px = 0.75pt
        _pdfDocument.SetDefaultPageSize(new PageSize(width * .75f, height * .75f));
        if (!_isFirstPage)
        {
            _document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
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
    private static void GetImageDimension(string filename, out int width, out int height)
    {
        using FileStream fileStream = new(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        using System.Drawing.Image img = System.Drawing.Image.FromStream(fileStream, false, false);
        (width, height) = (img.Width, img.Height);
    }
}
