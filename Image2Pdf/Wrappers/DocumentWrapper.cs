﻿using System.Diagnostics.CodeAnalysis;
using iText.Layout;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IDocument"/>.
/// </summary>
[ExcludeFromCodeCoverage]
internal class DocumentWrapper : Wrapper<Document>, IDocument
{
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="document">The wrapped object.</param>
    internal DocumentWrapper(Document document)
        : base(document)
    {
    }

    /// <inheritdoc/>
    public void SetMargins(float topMargin, float rightMargin, float bottomMargin, float leftMargin)
    {
        Unwrap().SetMargins(topMargin, rightMargin, bottomMargin, leftMargin);
    }

    /// <inheritdoc/>
    public IDocument Add(IAreaBreak areaBreak)
    {
        Unwrap().Add(areaBreak.Unwrap());
        return this;
    }

    /// <inheritdoc/>
    public IDocument Add(IImage image)
    {
        Unwrap().Add(image.Unwrap());
        return this;
    }

    /// <inheritdoc/>
    public void Close()
    {
        Unwrap().Close();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Close();
    }
}