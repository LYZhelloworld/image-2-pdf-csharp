using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Image2Pdf.Models;
using Image2Pdf.Generators;
using Microsoft.Win32;

namespace Image2Pdf;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
[ExcludeFromCodeCoverage]
public partial class MainWindow : Window
{
    /// <summary>
    /// The model.
    /// </summary>
    private readonly IMainWindowModel _model;

    /// <summary>
    /// The constructor.
    /// </summary>
    public MainWindow() : this(new MainWindowModel())
    {
    }

    /// <summary>
    /// The constructor with all properties.
    /// </summary>
    /// <param name="model">The model.</param>
    public MainWindow(IMainWindowModel model)
    {
        _model = model;
        _model.FileProcessedEvent += _model_FileProcessedEvent;
        _model.PdfGenerationCompletedEvent += _model_PdfGenerationCompletedEvent;

        InitializeComponent();
        FilenameList.ItemsSource = _model.ItemSource;
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
        _model.MoveUp(FilenameList.SelectedIndex);
        FilenameList.Items.Refresh();
    }

    /// <summary>
    /// Indicates whether <see cref="MoveUpCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void MoveUpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = _model.CanMoveUp(FilenameList.SelectedIndex);
    }

    /// <summary>
    /// The event handler of <see cref="MoveDownCommand"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void MoveDownCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        _model.MoveDown(FilenameList.SelectedIndex);
        FilenameList.Items.Refresh();
    }

    /// <summary>
    /// Indicates whether <see cref="MoveDownCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void MoveDownCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = _model.CanMoveDown(FilenameList.SelectedIndex);
    }

    /// <summary>
    /// The event handler of <see cref="RemoveCommand"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        _model.Remove(FilenameList.SelectedIndex);
        FilenameList.Items.Refresh();
    }

    /// <summary>
    /// Indicates whether <see cref="RemoveCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = _model.CanRemove(FilenameList.SelectedIndex);
    }

    /// <summary>
    /// Indicates whether <see cref="GenerateCommand"/> can be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void GenerateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = _model.CanGenerate();
    }

    /// <summary>
    /// The event handler of <see cref="GenerateCommand"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    private void GenerateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
        // Show save file dialog.
        SaveFileDialog saveFileDialog = new();

        // Default save path is the parent folder of the images.
        // Get path of image file.
        string? filepath = Path.GetDirectoryName(_model.ItemSource.FirstOrDefault());
        if (filepath != null)
        {
            // Get parent of the image file.
            DirectoryInfo? path = Directory.GetParent(filepath);

            // Use parent path, or file path instead if parent folder is not available
            // (e.g. at the root directory).
            saveFileDialog.InitialDirectory = path?.ToString() ?? filepath;
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
    private void _model_PdfGenerationCompletedEvent(object? sender, PdfGenerationCompletedEventArgs e)
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
    private void _model_FileProcessedEvent(object? sender, FileProcessedEventArgs e)
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
        string[] files = (string[]?)e.Data.GetData(DataFormats.FileDrop) ?? Array.Empty<string>();
        _model.AddFiles(files);
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
        GeneratorProgressBar.Maximum = _model.ItemSource.Count();

        _model.Generate(target);
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
        _model.Clear();
        FilenameList.Items.Refresh();
    }
}
