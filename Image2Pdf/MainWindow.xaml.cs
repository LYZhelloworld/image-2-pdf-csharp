// <copyright file="MainWindow.xaml.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using Image2Pdf.Generators;
    using Image2Pdf.Models;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly IMainWindowModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
            : this(new MainWindowModel())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MainWindow(IMainWindowModel model)
        {
            this.model = model;
            this.model.FileProcessedEvent += this.Model_FileProcessedEvent;
            this.model.PdfGenerationCompletedEvent += this.Model_PdfGenerationCompletedEvent;

            this.InitializeComponent();
            this.FilenameList.ItemsSource = this.model.ItemSource;
        }

        /// <summary>
        /// Gets the command to move up an item.
        /// </summary>
        public static RoutedCommand MoveUpCommand { get; } = new();

        /// <summary>
        /// Gets the command to move down an item.
        /// </summary>
        public static RoutedCommand MoveDownCommand { get; } = new();

        /// <summary>
        /// Gets the command to remove an item.
        /// </summary>
        public static RoutedCommand RemoveCommand { get; } = new();

        /// <summary>
        /// Gets the command to generate PDF file.
        /// </summary>
        public static RoutedCommand GenerateCommand { get; } = new();

        /// <summary>
        /// The event handler of <see cref="MoveUpCommand"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveUpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.model.MoveUp(this.FilenameList.SelectedIndex);
            this.FilenameList.Items.Refresh();
        }

        /// <summary>
        /// Indicates whether <see cref="MoveUpCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveUpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.model.CanMoveUp(this.FilenameList.SelectedIndex);
        }

        /// <summary>
        /// The event handler of <see cref="MoveDownCommand"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveDownCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.model.MoveDown(this.FilenameList.SelectedIndex);
            this.FilenameList.Items.Refresh();
        }

        /// <summary>
        /// Indicates whether <see cref="MoveDownCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveDownCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.model.CanMoveDown(this.FilenameList.SelectedIndex);
        }

        /// <summary>
        /// The event handler of <see cref="RemoveCommand"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.model.Remove(this.FilenameList.SelectedIndex);
            this.FilenameList.Items.Refresh();
        }

        /// <summary>
        /// Indicates whether <see cref="RemoveCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.model.CanRemove(this.FilenameList.SelectedIndex);
        }

        /// <summary>
        /// Indicates whether <see cref="GenerateCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void GenerateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.model.CanGenerate();
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
            string? filepath = Path.GetDirectoryName(this.model.ItemSource.FirstOrDefault());
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

            this.StartPdfGeneration(saveFileDialog.FileName);
        }

        /// <summary>
        /// The event handler of <see cref="IPdfGenerator{TFileProcessedEventArgs, TPdfGenerationCompletedEventArgs}.PdfGenerationCompletedEvent"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void Model_PdfGenerationCompletedEvent(object? sender, PdfGenerationCompletedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
            // prompt message box to open file
                if (MessageBox.Show(
                    string.Format(CultureInfo.CurrentCulture, Properties.Resources.PdfGenerationCompletedPrompt, e.PdfFilename),
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

                this.FinishPdfGeneration();
            });
        }

        /// <summary>
        /// The event handler of <see cref="IPdfGenerator{TFileProcessedEventArgs, TPdfGenerationCompletedEventArgs}.FileProcessedEvent"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void Model_FileProcessedEvent(object? sender, FileProcessedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.GeneratorProgressBar.Value = e.Progress;
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop) ?? Array.Empty<string>();
            this.model.AddFiles(files);
            this.FilenameList.Items.Refresh();
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Starts PDF generation.
        /// </summary>
        /// <param name="target">The PDF filename.</param>
        private void StartPdfGeneration(string target)
        {
            // disable controls
            this.FilenameList.IsEnabled = false;
            this.GenerateButton.IsEnabled = false;
            this.GeneratorProgressBar.IsEnabled = true;
            this.GeneratorProgressBar.Maximum = this.model.ItemSource.Count();

            this.model.Generate(target);
        }

        /// <summary>
        /// Finishes PDF generation.
        /// </summary>
        private void FinishPdfGeneration()
        {
            // enable controls
            this.FilenameList.IsEnabled = true;
            this.GenerateButton.IsEnabled = true;
            this.GeneratorProgressBar.IsEnabled = false;
            this.GeneratorProgressBar.Value = 0;

            // clear file list
            this.model.Clear();
            this.FilenameList.Items.Refresh();
        }
    }
}
