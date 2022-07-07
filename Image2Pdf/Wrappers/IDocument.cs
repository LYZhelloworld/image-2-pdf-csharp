﻿using System;
using iText.Layout;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="iText.Layout.Document"/>.
/// </summary>
public interface IDocument : IDisposable
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    internal Document Document { get; }

    /// <summary>
    /// The wrapper method of <see cref="Document.Add(iText.Layout.Element.AreaBreak)"/>.
    /// </summary>
    /// <param name="areaBreak">The <see cref="IAreaBreak"/> object.</param>
    /// <returns>This element.</returns>
    IDocument Add(IAreaBreak areaBreak);

    /// <summary>
    /// The wrapper method of <see cref="RootElement{T}.Add(iText.Layout.Element.Image)"/>.
    /// </summary>
    /// <param name="image">The <see cref="IImage"/> object.</param>
    /// <returns>This element.</returns>
    IDocument Add(IImage image);

    /// <summary>
    /// The wrapper method of <see cref="Document.SetMargins(float, float, float, float)"/>.
    /// </summary>
    /// <param name="topMargin">The upper margin.</param>
    /// <param name="rightMargin">The right margin.</param>
    /// <param name="bottomMargin">The bottom margin.</param>
    /// <param name="leftMargin">The left margin.</param>
    void SetMargins(float topMargin, float rightMargin, float bottomMargin, float leftMargin);

    /// <summary>
    /// The wrapper method of <see cref="Document.Close"/>.
    /// </summary>
    void Close();
}
