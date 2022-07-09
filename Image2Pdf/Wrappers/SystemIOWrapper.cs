using System.Diagnostics.CodeAnalysis;

namespace Image2Pdf.Wrappers;

/// <summary>
/// Implementation of <see cref="ISystemIOWrapper"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class SystemIOWrapper : ISystemIOWrapper
{
    /// <inheritdoc/>
    public IFileStreamFactory FileStream { get; } = new FileStreamFactory();
}
