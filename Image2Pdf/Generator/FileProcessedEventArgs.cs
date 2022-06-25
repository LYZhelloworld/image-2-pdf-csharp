namespace Image2Pdf.Generator
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The arguments of the event <see cref="PdfGenerator.FileProcessedEvent"/>.
    /// </summary>
    /// <param name="Filename">The file processed.</param>
    /// <param name="Progress">The number of files processed.</param>
    [ExcludeFromCodeCoverage]
    public record FileProcessedEventArgs(string Filename, int Progress);
}
