namespace Image2Pdf.Generator
{
    /// <summary>
    /// The arguments of the event <see cref="PdfGenerator.PdfGenerationCompletedEvent"/>.
    /// </summary>
    /// <param name="PdfFilename">The PDF file name.</param>
    public record PdfGenerationCompletedEventArgs(string PdfFilename);
}
