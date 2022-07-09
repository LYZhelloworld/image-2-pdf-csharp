namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class of <see cref="System.IO"/> operations.
/// </summary>
public interface ISystemIOWrapper
{
    /// <summary>
    /// The wrapper object of <see cref="System.IO.FileStream"/>.
    /// </summary>
    IFileStreamFactory FileStream { get; }
}
