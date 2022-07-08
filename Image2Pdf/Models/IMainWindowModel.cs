using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Image2Pdf.Generators;

namespace Image2Pdf.Models;

/// <summary>
/// The model of <see cref="MainWindow"/>.
/// </summary>
public interface IMainWindowModel
{
    #region Properties
    /// <summary>
    /// The item source.
    /// </summary>
    IEnumerable<string> ItemSource { get; }
    #endregion

    #region Commands
    /// <summary>
    /// Adds image files to the list.
    /// </summary>
    /// <param name="files">The filenames to add.</param>
    void AddFiles(params string[] files);

    /// <summary>
    /// Removes all files.
    /// </summary>
    void Clear();

    /// <summary>
    /// The command to move up an item.
    /// </summary>
    /// <param name="index">The index of the selected item.</param>
    void MoveUp(int index);

    /// <summary>
    /// Indicates whether <see cref="MoveUp(int)"/> can be executed.
    /// </summary>
    /// <param name="index">The index of the selected item.</param>
    bool CanMoveUp(int index);

    /// <summary>
    /// The command to move down an item.
    /// </summary>
    /// <param name="index">The index of the selected item.</param>
    void MoveDown(int index);

    /// <summary>
    /// Indicates whether <see cref="MoveDown(int)"/> can be executed.
    /// </summary>
    /// <param name="index">The index of the selected item.</param>
    bool CanMoveDown(int index);

    /// <summary>
    /// The command to remove an item.
    /// </summary>
    /// <param name="index">The index of the selected item.</param>
    void Remove(int index);

    /// <summary>
    /// Indicates whether <see cref="Remove(int)"/> can be executed.
    /// </summary>
    /// <param name="index">The index of the selected item.</param>
    bool CanRemove(int index);

    /// <summary>
    /// The command to remove an item.
    /// </summary>
    /// <param name="pdfFilename">The PDF filename.</param>
    /// <returns>A <see cref="Task"/> that does PDF generation.</returns>
    Task Generate(string pdfFilename);

    /// <summary>
    /// Indicates whether <see cref="Generate"/> can be executed.
    /// </summary>
    bool CanGenerate();
    #endregion

    #region Events
    /// <summary>
    /// The event that a file has been processed.
    /// </summary>
    event EventHandler<FileProcessedEventArgs>? FileProcessedEvent;

    /// <summary>
    /// The event that the PDF has been generated.
    /// </summary>
    event EventHandler<PdfGenerationCompletedEventArgs>? PdfGenerationCompletedEvent;
    #endregion
}
