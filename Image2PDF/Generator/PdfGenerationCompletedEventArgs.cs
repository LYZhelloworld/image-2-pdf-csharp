namespace Image2Pdf.Generator
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The arguments of the event <see cref="PdfGenerator.PdfGenerationCompletedEvent"/>.
    /// </summary>
    /// <param name="PdfFilename">The PDF file name.</param>
    [ExcludeFromCodeCoverage]
    public record PdfGenerationCompletedEventArgs(string PdfFilename);
}
