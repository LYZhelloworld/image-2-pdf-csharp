namespace Image2Pdf.Interface
{
    using Image2Pdf.Generator;

    /// <summary>
    /// The PDF file generator.
    /// </summary>
    public interface IPdfGenerator
    {
        /// <summary>
        /// Generates PDF file.
        /// </summary>
        /// <param name="target">The PDF file location.</param>
        public void Generate(string target);

        /// <summary>
        /// The handler of the event that a file has been processed.
        /// </summary>
        /// <param name="sender">The sender object, i.e., the PdfGenerator instance.</param>
        /// <param name="e">The arguments.</param>
        public delegate void FileProcessedEventHandler(object sender, FileProcessedEventArgs e);

        /// <summary>
        /// The event that a file has been processed.
        /// </summary>
        public event FileProcessedEventHandler? FileProcessedEvent;

        /// <summary>
        /// The handler of the event that the PDF has been generated.
        /// </summary>
        /// <param name="sender">The sender object, i.e., the PdfGenerator instance.</param>
        /// <param name="e">The arguments.</param>
        public delegate void PdfGenerationCompletedEventHandler(object sender, PdfGenerationCompletedEventArgs e);

        /// <summary>
        /// The event that the PDF has been generated.
        /// </summary>
        public event PdfGenerationCompletedEventHandler? PdfGenerationCompletedEvent;
    }
}
