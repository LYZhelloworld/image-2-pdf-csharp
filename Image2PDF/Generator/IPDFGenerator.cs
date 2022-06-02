namespace Image2PDF.PDFGenerator
{
    /// <summary>
    /// The arguments of the event FileProcessedEvent.
    /// </summary>
    public class FileProcessedEventArgs
    {
        public string Filename { get; set; } = default!;
        public int Progress { get; set; }
    }

    /// <summary>
    /// The arguments of the event PDFGenerationCompletedEvent.
    /// </summary>
    public class PDFGenerationCompletedEventArgs
    {
        public string PDFFilename { get; set; } = default!;
    }

    /// <summary>
    /// The interface of PDFGenerator.
    /// </summary>
    public interface IPDFGenerator
    {
        /// <summary>
        /// Generate PDF file.
        /// </summary>
        /// <param name="target">The PDF file location.</param>
        public void Generate(string target);

        /// <summary>
        /// The handler of the event that a file has been processed.
        /// </summary>
        /// <param name="sender">The sender object, i.e., the PDFGenerator instance.</param>
        /// <param name="e">The arguments.</param>
        public delegate void FileProcessedEventHandler(object sender, FileProcessedEventArgs e);

        /// <summary>
        /// The event that a file has been processed.
        /// </summary>
        public event FileProcessedEventHandler? FileProcessedEvent;

        /// <summary>
        /// The handler of the event that the PDF has been generated.
        /// </summary>
        /// <param name="sender">The sender object, i.e., the PDFGenerator instance.</param>
        /// <param name="e">The arguments.</param>
        public delegate void PDFGenerationCompletedEventHandler(object sender, PDFGenerationCompletedEventArgs e);

        /// <summary>
        /// The event that the PDF has been generated.
        /// </summary>
        public event PDFGenerationCompletedEventHandler? PDFGenerationCompletedEvent;
    }
}
