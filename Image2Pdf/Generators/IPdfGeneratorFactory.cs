using System.Collections.Generic;

namespace Image2Pdf.Generators;

/// <summary>
/// The factory class of <see cref="IPdfGenerator"/>.
/// </summary>
public interface IPdfGeneratorFactory
{
    /// <summary>
    /// Adds image filenames.
    /// </summary>
    /// <param name="files">The image filenames.</param>
    /// <returns>The current factory instance.</returns>
    IPdfGeneratorFactory AddFiles(IEnumerable<string> files);

    /// <summary>
    /// Builds an instance of <see cref="IPdfGenerator"/>.
    /// </summary>
    /// <returns>The instance.</returns>
    IPdfGenerator Build();
}
