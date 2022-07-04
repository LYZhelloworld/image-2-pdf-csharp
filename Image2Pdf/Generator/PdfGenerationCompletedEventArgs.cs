using System;
using System.Diagnostics.CodeAnalysis;

namespace Image2Pdf.Generator;

/// <summary>
/// The arguments of the PDF generation completed event.
/// </summary>
[ExcludeFromCodeCoverage]
public class PdfGenerationCompletedEventArgs : EventArgs
{
    /// <summary>
    /// The PDF file name.
    /// </summary>
    public string PdfFilename { get; init; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="pdfFilename">The PDF file name.</param>
    public PdfGenerationCompletedEventArgs(string pdfFilename)
    {
        PdfFilename = pdfFilename;
    }
}
