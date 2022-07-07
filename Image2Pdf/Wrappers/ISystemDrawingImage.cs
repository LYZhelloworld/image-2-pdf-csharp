using System;
using System.Drawing;

namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="Image"/>.
/// </summary>
public interface ISystemDrawingImage : IWrapper<Image>, IDisposable
{
    /// <summary>
    /// The wrapped property of <see cref="Image.Width"/>.
    /// </summary>
    int Width { get; }

    /// <summary>
    /// The wrapped property of <see cref="Image.Height"/>.
    /// </summary>
    int Height { get; }
}
