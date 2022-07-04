using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Image2Pdf.Generator;
using Image2Pdf.Interfaces;
using Image2Pdf.Utility;
using Microsoft.Win32;

namespace Image2Pdf;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
[ExcludeFromCodeCoverage]
public partial class MainWindow : Window
{
    /// <summary>
    /// The factory class of PDF generator.
    /// </summary>
    private readonly PdfGeneratorFactory _pdfGeneratorFactory;

    /// <summary>
    /// The filenames of images.
    /// </summary>
    private readonly List<string> _filenames;

    /// <summary>
    /// The constructor.
    /// </summary>
    public MainWindow() : this(new PdfGeneratorFactory(), new List<string>())
    {
    }

    /// <summary>
    /// The constructor with all arguments.
    /// </summary>
    /// <param name="pdfGeneratorFactory">The factory class of PDF generator.</param>
    /// <param name="filenames">The filenames of images.</param>
    public MainWindow(PdfGeneratorFactory pdfGeneratorFactory, IEnumerable<string> filenames)
    {
        _pdfGeneratorFactory = pdfGeneratorFactory;
        _filenames = filenames.ToList();

        InitializeComponent();
        FilenameList.ItemsSource = _filenames;
    }

    #region Commands
    /// <summary>
    /// The command to move up an item.
    /// </summary>
    public static RoutedCommand MoveUpCommand { get; } = new();

    /// <summary>
    /// The command to move down an item.
    /// </summary>
    public static RoutedCommand MoveDownCommand { get; } = new();

    /// <summary>
    /// The command to remove an item.
    /// </summary>
    public static RoutedCommand RemoveCommand { get; } = new();

    /// <summary>
    /// The command to generate PDF file.
    /// </summary>
    public static RoutedCommand GenerateCommand { get; } = new();
    #endregion

    #region EventHandlers

    /// <summary>
    /// The event handler of <see cref="MoveUpCommand"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void MoveUpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        int index = FilenameList.SelectedIndex;
        (_filenames[index], _filenames[index - 1]) = (_filenames[index - 1], _filenames[index]);
        FilenameList.Items.Refresh();
    }

    /// <summary>
    /// Indicates whether <see cref="MoveUpCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void MoveUpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = FilenameList.SelectedIndex != -1 && FilenameList.SelectedIndex > 0;
    }

    /// <summary>
    /// The event handler of <see cref="MoveDownCommand"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void MoveDownCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        int index = FilenameList.SelectedIndex;
        (_filenames[index], _filenames[index + 1]) = (_filenames[index + 1], _filenames[index]);
        FilenameList.Items.Refresh();
    }

    /// <summary>
    /// Indicates whether <see cref="MoveDownCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void MoveDownCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = FilenameList.SelectedIndex != -1 && FilenameList.SelectedIndex < FilenameList.Items.Count - 1;
    }

    /// <summary>
    /// The event handler of <see cref="RemoveCommand"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        int index = FilenameList.SelectedIndex;
        _filenames.RemoveAt(index);
        FilenameList.Items.Refresh();
    }

    /// <summary>
    /// Indicates whether <see cref="RemoveCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = FilenameList.SelectedIndex != -1;
    }

    /// <summary>
    /// Indicates whether <see cref="GenerateCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void GenerateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = FilenameList.Items.Count > 0;
    }

    /// <summary>
    /// The event handler of <see cref="GenerateCommand"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void GenerateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
        // Show save file dialog.
        SaveFileDialog? saveFileDialog = new();

        // Default save path is the parent folder of the images.
        // Get path of image file.
        string? filepath = Path.GetDirectoryName(_filenames[0]);
        if (filepath != null)
        {
            // Get parent of the image file.
            DirectoryInfo? path = Directory.GetParent(filepath);
            if (path != null)
            {
                // Use parent path.
                saveFileDialog.InitialDirectory = path.ToString();
            }
            else
            {
                // Cannot get parent (e.g. at the root directory) folder, use file path instead.
                saveFileDialog.InitialDirectory = filepath;
            }
        }
        else
        {
            // Cannot get the path of image file, fallback to My Documents.
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        saveFileDialog.Filter = Properties.Resources.PdfSaveDialogFilter;
        if (!saveFileDialog.ShowDialog(this) ?? false)
        {
            return;
        }

        StartPdfGeneration(saveFileDialog.FileName);
    }

    /// <summary>
    /// The event handler of <see cref="IPdfGenerator.PdfGenerationCompletedEvent"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void PdfGenerator_PdfGenerationCompletedEvent(object? sender, PdfGenerationCompletedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            // prompt message box to open file
            if (MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Properties.Resources.PdfGenerationCompletedPrompt, e.PdfFilename),
                Properties.Resources.AppName,
                MessageBoxButton.YesNo,
                MessageBoxImage.Information,
                MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                string? directory = Path.GetDirectoryName(e.PdfFilename);
                if (directory != null)
                {
                    Process.Start("explorer.exe", directory);
                }
            }

            FinishPdfGeneration();
        });
    }

    /// <summary>
    /// The event handler of <see cref="IPdfGenerator.FileProcessedEvent"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void PdfGenerator_FileProcessedEvent(object? sender, FileProcessedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            GeneratorProgressBar.Value = e.Progress;
        });
    }

    /// <summary>
    /// The event handler of dropping files on the list view.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void FilenameList_Drop(object sender, DragEventArgs e)
    {
        // get file list from the dropped data
        string[]? files = (string[])e.Data.GetData(DataFormats.FileDrop);
        foreach (string? file in files)
        {
            // add valid image files only
            // ignore others
            if (FileUtils.IsValidImageFile(file))
            {
                _filenames.Add(file);
            }
        }
        FilenameList.Items.Refresh();
        CommandManager.InvalidateRequerySuggested();
    }
    #endregion

    /// <summary>
    /// Starts PDF generation.
    /// </summary>
    /// <param name="target">The PDF filename.</param>
    private void StartPdfGeneration(string target)
    {
        // disable controls
        FilenameList.IsEnabled = false;
        GenerateButton.IsEnabled = false;
        GeneratorProgressBar.IsEnabled = true;
        GeneratorProgressBar.Maximum = _filenames.Count;

        // create PDF generator
        IPdfGenerator<FileProcessedEventArgs, PdfGenerationCompletedEventArgs> pdfGenerator = _pdfGeneratorFactory.AddFiles(_filenames).Build();

        pdfGenerator.PdfGenerationCompletedEvent += PdfGenerator_PdfGenerationCompletedEvent;
        pdfGenerator.FileProcessedEvent += PdfGenerator_FileProcessedEvent;
        Task.Run(() =>
        {
            pdfGenerator.Generate(target);
        });
    }

    /// <summary>
    /// Finishes PDF generation.
    /// </summary>
    private void FinishPdfGeneration()
    {
        // enable controls
        FilenameList.IsEnabled = true;
        GenerateButton.IsEnabled = true;
        GeneratorProgressBar.IsEnabled = false;
        GeneratorProgressBar.Value = 0;

        // clear file list
        _filenames.Clear();
        FilenameList.Items.Refresh();
    }
}
