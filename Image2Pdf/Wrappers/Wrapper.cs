using System.Diagnostics.CodeAnalysis;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="IWrapper{T}"/>
/// </summary>
/// <typeparam name="T">The type of the wrapped object.</typeparam>
[ExcludeFromCodeCoverage]
internal class Wrapper<T> : IWrapper<T>
{
    /// <summary>
    /// The wrapped object.
    /// </summary>
    private readonly T _wrapped;

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="wrapped">The wrapped object.</param>
    public Wrapper(T wrapped)
    {
        _wrapped = wrapped;
    }

    /// <inheritdoc/>
    public T Unwrap()
    {
        return _wrapped;
    }
}
