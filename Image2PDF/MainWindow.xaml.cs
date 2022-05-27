﻿using Image2PDF.PDFGenerator;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Image2PDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> filenames;

        public MainWindow()
        {
            InitializeComponent();

            filenames = new List<string>();
            FilenameList.ItemsSource = filenames;
        }

        #region Commands
        public static readonly RoutedCommand MoveUpCommand = new();
        public static readonly RoutedCommand MoveDownCommand = new();
        public static readonly RoutedCommand RemoveCommand = new();
        public static readonly RoutedCommand GenerateCommand = new();
        #endregion

        #region EventHandlers
        private void MoveUpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var index = FilenameList.SelectedIndex;
            (filenames[index], filenames[index - 1]) = (filenames[index - 1], filenames[index]);
            FilenameList.Items.Refresh();
        }

        private void MoveUpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = FilenameList.SelectedIndex != -1 && FilenameList.SelectedIndex > 0;
        }

        private void MoveDownCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var index = FilenameList.SelectedIndex;
            (filenames[index], filenames[index + 1]) = (filenames[index + 1], filenames[index]);
            FilenameList.Items.Refresh();
        }

        private void MoveDownCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = FilenameList.SelectedIndex != -1 && FilenameList.SelectedIndex < FilenameList.Items.Count - 1;
        }

        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var index = FilenameList.SelectedIndex;
            filenames.RemoveAt(index);
            FilenameList.Items.Refresh();
        }

        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = FilenameList.SelectedIndex != -1;
        }


        private void GenerateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = FilenameList.Items.Count > 0;
        }

        private void GenerateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            // show save file dialog
            SaveFileDialog saveFileDialog = new();
            // default save path is the parent folder of the images
            // get path of image file
            var filepath = Path.GetDirectoryName(filenames[0]);
            if (filepath != null)
            {
                // get parent of the image file
                var path = Directory.GetParent(filepath);
                if (path != null)
                {
                    // use parent path
                    saveFileDialog.InitialDirectory = path.ToString();
                }
                else
                {
                    // cannot get parent (e.g. at the root directory), use file path instead
                    saveFileDialog.InitialDirectory = filepath;
                }
            }
            else
            {
                // cannot get the path of image file, fallback to My Documents
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            saveFileDialog.Filter = Properties.Resources.PDFSaveDialogFilter;
            if (!saveFileDialog.ShowDialog(this) ?? false) return;

            StartPDFGeneration(saveFileDialog.FileName);
        }

        private void PdfGenerator_PDFGenerationCompletedEvent(object sender, PDFGenerationCompletedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                // prompt message box to open file
                if (MessageBox.Show(string.Format(Properties.Resources.PDFGenerationCompletedPrompt, e.PDFFilename),
                    Properties.Resources.AppName,
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information,
                    MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    var directory = Path.GetDirectoryName(e.PDFFilename);
                    if (directory != null)
                        Process.Start("explorer.exe", directory);
                }

                FinishPDFGeneration();
            });
        }
        private void PdfGenerator_FileProcessedEvent(object sender, FileProcessedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                GeneratorProgressBar.Value = e.Progress;
            });
        }

        private void FilenameList_Drop(object sender, DragEventArgs e)
        {
            // get file list from the dropped data
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                // add valid image files only
                // ignore others
                if (FileUtils.IsValidImageFile(file))
                {
                    filenames.Add(file);
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
        private void StartPDFGeneration(string target)
        {
            // disable controls
            FilenameList.IsEnabled = false;
            GenerateButton.IsEnabled = false;
            GeneratorProgressBar.IsEnabled = true;
            GeneratorProgressBar.Maximum = filenames.Count;

            // create PDF generator
            var pdfGenerator = PDFGeneratorFactory.CreateFromFiles(filenames);
            // TODO: add event handler for progress

            pdfGenerator.PDFGenerationCompletedEvent += PdfGenerator_PDFGenerationCompletedEvent;
            pdfGenerator.FileProcessedEvent += PdfGenerator_FileProcessedEvent;
            Task.Run(() =>
            {
                pdfGenerator.Generate(target);
            });
        }

        /// <summary>
        /// Finishes PDF generation.
        /// </summary>
        private void FinishPDFGeneration()
        {
            // enable controls
            FilenameList.IsEnabled = true;
            GenerateButton.IsEnabled = true;
            GeneratorProgressBar.IsEnabled = false;
            GeneratorProgressBar.Value = 0;

            // clear file list
            filenames.Clear();
            FilenameList.Items.Refresh();
        }
    }
}
