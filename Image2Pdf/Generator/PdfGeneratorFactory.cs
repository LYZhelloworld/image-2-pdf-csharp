namespace Image2Pdf.Generator
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Image2Pdf.Interface;

    /// <summary>
    /// The factory class of <see cref="IPdfGenerator"/>.
    /// </summary>
    public class PdfGeneratorFactory : IPdfGeneratorFactory
    {
        /// <summary>
        /// The image filenames.
        /// </summary>
        private IEnumerable<string>? files;

        /// <summary>
        /// Adds image filenames.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        /// <returns>The current factory instance.</returns>
        public PdfGeneratorFactory AddFiles(IEnumerable<string> files)
        {
            this.files = files;
            return this;
        }

        /// <summary>
        /// Builds an instance of <see cref="IPdfGenerator"/>.
        /// </summary>
        /// <returns>The instance.</returns>
        public IPdfGenerator Build()
        {
            Debug.Assert(this.files != null);

            return new PdfGenerator(this.files);
        }
    }
}
