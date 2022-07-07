namespace Image2Pdf.Wrappers;

/// <summary>
/// The wrapper class.
/// </summary>
/// <typeparam name="T">The type of the wrapped object.</typeparam>
public interface IWrapper<T>
{
    /// <summary>
    /// Gets the wrapped object.
    /// </summary>
    /// <returns>The wrapped object.</returns>
    T Unwrap();
}
