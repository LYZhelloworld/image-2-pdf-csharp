namespace Image2Pdf.Adapter
{
    using Image2Pdf.Interface;

    /// <summary>
    /// The factory class of <see cref="IPdfAdapter"/>.
    /// </summary>
    public class PdfAdapterFactory : IPdfAdapterFactory
    {
        /// <summary>
        /// Creates default PDF adapter.
        /// </summary>
        /// <returns>The adapter.</returns>
        public IPdfAdapter CreateAdapter()
        {
            return new PdfAdapter();
        }
    }
}
