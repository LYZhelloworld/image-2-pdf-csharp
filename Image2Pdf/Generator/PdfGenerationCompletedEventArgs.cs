namespace Image2Pdf.Generator
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The arguments of the event <see cref="PdfGenerator.PdfGenerationCompletedEvent"/>.
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
            this.PdfFilename = pdfFilename;
        }
    }
}
