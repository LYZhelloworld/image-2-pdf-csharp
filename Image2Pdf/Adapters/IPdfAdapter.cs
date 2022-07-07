using System;

namespace Image2Pdf.Adapters;

/// <summary>
/// The adapter of PDF generator.
/// </summary>
public interface IPdfAdapter : IDisposable
{
    /// <summary>
    /// Adds a page with image as background.
    /// </summary>
    /// <param name="imageFilename">The filename of the image.</param>
    void AddPageWithImage(string imageFilename);

    /// <summary>
    /// Creates a PDF document from the filename.
    /// </summary>
    /// <param name="pdfFileName">The PDF filename.</param>
    void CreatePdfDocumentFromFilename(string pdfFileName);
}
