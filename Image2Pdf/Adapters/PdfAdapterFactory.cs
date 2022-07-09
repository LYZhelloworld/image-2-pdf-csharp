namespace Image2Pdf.Adapters;

/// <summary>
/// The factory class of <see cref="IPdfAdapter"/>.
/// </summary>
public class PdfAdapterFactory : IPdfAdapterFactory
{
    /// <inheritdoc/>
    public IPdfAdapter CreateAdapter()
    {
        return new PdfAdapter();
    }
}
