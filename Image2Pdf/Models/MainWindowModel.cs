using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Image2Pdf.Generators;
using Image2Pdf.Utilities;

namespace Image2Pdf.Models;

/// <summary>
/// Implementation of <see cref="IMainWindowModel"/>.
/// </summary>
public class MainWindowModel : IMainWindowModel
{
    #region Fields
    /// <summary>
    /// The factory class of PDF generator.
    /// </summary>
    private readonly IPdfGeneratorFactory _pdfGeneratorFactory;

    /// <summary>
    /// The filenames of images.
    /// </summary>
    private readonly List<string> _filenames = new();
    #endregion

    #region Constructors
    /// <summary>
    /// The constructor.
    /// </summary>
    public MainWindowModel()
        : this(new PdfGeneratorFactory())
    {
    }

    /// <summary>
    /// The constructor with all properties.
    /// </summary>
    /// <param name="pdfGeneratorFactory">The factory class of PDF generator.</param>
    public MainWindowModel(IPdfGeneratorFactory pdfGeneratorFactory)
    {
        _pdfGeneratorFactory = pdfGeneratorFactory;
    }
    #endregion

    #region Properties
    /// <inheritdoc/>
    public IEnumerable<string> ItemSource => _filenames;
    #endregion

    #region Methods
    /// <inheritdoc/>
    public void AddFiles(params string[] files)
    {
        // Add valid image files only. Ignore others.
        _filenames.AddRange(files.Where(FileUtils.IsValidImageFile));
    }

    /// <summary>
    /// Removes all files.
    /// </summary>
    public void Clear()
    {
        _filenames.Clear();
    }
    #endregion

    #region Commands
    /// <inheritdoc/>
    public void MoveUp(int index)
    {
        (_filenames[index], _filenames[index - 1]) = (_filenames[index - 1], _filenames[index]);
    }

    /// <inheritdoc/>
    public bool CanMoveUp(int index)
    {
        return index != -1 && index > 0;
    }

    /// <inheritdoc/>
    public void MoveDown(int index)
    {
        (_filenames[index], _filenames[index + 1]) = (_filenames[index + 1], _filenames[index]);
    }

    /// <inheritdoc/>
    public bool CanMoveDown(int index)
    {
        return index != -1 && index < _filenames.Count - 1;
    }

    /// <inheritdoc/>
    public void Remove(int index)
    {
        _filenames.RemoveAt(index);
    }

    /// <inheritdoc/>
    public bool CanRemove(int index)
    {
        return index != -1;
    }

    /// <inheritdoc/>
    public void Generate(string pdfFilename)
    {
        // create PDF generator
        IPdfGenerator<FileProcessedEventArgs, PdfGenerationCompletedEventArgs> pdfGenerator = _pdfGeneratorFactory.AddFiles(_filenames).Build();

        pdfGenerator.FileProcessedEvent += (sender, e) => FileProcessedEvent?.Invoke(sender, e);
        pdfGenerator.PdfGenerationCompletedEvent += (sender, e) => PdfGenerationCompletedEvent?.Invoke(sender, e);
        Task.Run(() =>
        {
            pdfGenerator.Generate(pdfFilename);
        });
    }

    /// <inheritdoc/>
    public bool CanGenerate()
    {
        return _filenames.Count > 0;
    }
    #endregion

    #region Events
    /// <inheritdoc/>
    public event EventHandler<FileProcessedEventArgs>? FileProcessedEvent;

    /// <inheritdoc/>
    public event EventHandler<PdfGenerationCompletedEventArgs>? PdfGenerationCompletedEvent;
    #endregion
}
