using Image2PDF.PDFGenerator;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        #region CommandHandlers
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
            e.CanExecute = filenames.Count > 0;
        }

        private void GenerateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            // show save file dialog
            SaveFileDialog saveFileDialog = new();
            // default save path is the parent folder of the images
            var path = Path.GetDirectoryName(filenames[0]);
            if (path == null)
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                saveFileDialog.InitialDirectory = Path.Combine(path, "..");
            }
            saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
            if (!saveFileDialog.ShowDialog(this) ?? false) return;

            // create PDF generator
            var pdfGenerator = PDFGeneratorFactory.CreateFromFiles(filenames);
            // TODO: add event handler for progress

            pdfGenerator.PDFGenerationCompletedEvent += PdfGenerator_PDFGenerationCompletedEvent;
        }

        private void PdfGenerator_PDFGenerationCompletedEvent(object sender, PDFGenerationCompletedEventArgs e)
        {
            // prompt message box to open file
            if (MessageBox.Show("The PDF file has been saved to the location:\n" +
                $"{e.PDFFilename}\n" +
                "Do you want to open it?",
                "Image2PDF",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information,
                MessageBoxResult.Yes) != MessageBoxResult.Yes)
            {
                return;
            }

            var directory = Path.GetDirectoryName(e.PDFFilename);
            if (directory != null)
                Process.Start("explorer.exe", directory);
        }
        #endregion

        private void FilenameList_Drop(object sender, DragEventArgs e)
        {
            // get file list from the dropped data
            var files = ((string[])e.Data.GetData(DataFormats.FileDrop));
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
        }
    }
}
