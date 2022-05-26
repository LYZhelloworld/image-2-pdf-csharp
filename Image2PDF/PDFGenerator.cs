using System;

namespace Image2PDF
{
    internal class PDFGenerator : IPDFGenerator
    {
        public event IPDFGenerator.FileProcessedEventHandler? FileProcessedEvent;
        public event IPDFGenerator.PDFGenerationCompletedEventHandler? PDFGenerationCompletedEvent;

        public void Generate(string target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Trigger the event when a file has been processed.
        /// </summary>
        /// <param name="filename">The filename that has been processed.</param>
        /// <param name="progress">ID of the file processed.</param>
        /// <param name="total">Total number of files.</param>
        protected virtual void OnFileProcessedEvent(string filename, int progress, int total)
        {
            FileProcessedEvent?.Invoke(this, new FileProcessedEventArgs
            {
                Filename = filename,
                Progress = progress,
                Total = total,
            });
        }

        protected virtual void OnPDFGenerationCompletedEvent()
        {
            PDFGenerationCompletedEvent?.Invoke(this, new PDFGenerationCompletedEventArgs());
        }
    }
}
