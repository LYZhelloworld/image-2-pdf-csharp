using System.Diagnostics.CodeAnalysis;
using iText.Layout;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IDocument"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class DocumentWrapper : IDocument
{
    /// <inheritdoc/>
    public Document Document { get; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="document">The wrapped object.</param>
    internal DocumentWrapper(Document document)
    {
        Document = document;
    }

    /// <inheritdoc/>
    public void SetMargins(float topMargin, float rightMargin, float bottomMargin, float leftMargin)
    {
        Document.SetMargins(topMargin, rightMargin, bottomMargin, leftMargin);
    }

    /// <inheritdoc/>
    public IDocument Add(IAreaBreak areaBreak)
    {
        Document.Add(areaBreak.AreaBreak);
        return this;
    }

    /// <inheritdoc/>
    public IDocument Add(IImage image)
    {
        Document.Add(image.Image);
        return this;
    }

    /// <inheritdoc/>
    public void Close()
    {
        Document.Close();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Close();
    }
}
