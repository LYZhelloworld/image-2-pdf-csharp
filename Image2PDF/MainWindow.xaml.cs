namespace Image2PDF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using Image2PDF.PDFGenerator;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The PDF generator factory.
        /// </summary>
        private readonly IPDFGeneratorFactory pdfGeneratorFactory;

        /// <summary>
        /// The filenames of images.
        /// </summary>
        private readonly List<string> filenames;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="pdfGeneratorFactory">The PDF generator factory.</param>
        public MainWindow(IPDFGeneratorFactory pdfGeneratorFactory)
        {
            this.pdfGeneratorFactory = pdfGeneratorFactory;

            this.InitializeComponent();

            this.filenames = new List<string>();
            this.FilenameList.ItemsSource = this.filenames;
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
            int index = this.FilenameList.SelectedIndex;
            (this.filenames[index], this.filenames[index - 1]) = (this.filenames[index - 1], this.filenames[index]);
            this.FilenameList.Items.Refresh();
        }

        private void MoveUpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.SelectedIndex != -1 && this.FilenameList.SelectedIndex > 0;
        }

        private void MoveDownCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = this.FilenameList.SelectedIndex;
            (this.filenames[index], this.filenames[index + 1]) = (this.filenames[index + 1], this.filenames[index]);
            this.FilenameList.Items.Refresh();
        }

        private void MoveDownCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.SelectedIndex != -1 && this.FilenameList.SelectedIndex < this.FilenameList.Items.Count - 1;
        }

        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = this.FilenameList.SelectedIndex;
            this.filenames.RemoveAt(index);
            this.FilenameList.Items.Refresh();
        }

        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.SelectedIndex != -1;
        }


        private void GenerateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.Items.Count > 0;
        }

        private void GenerateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            // show save file dialog
            SaveFileDialog? saveFileDialog = new SaveFileDialog();
            // default save path is the parent folder of the images
            // get path of image file
            string? filepath = Path.GetDirectoryName(this.filenames[0]);
            if (filepath != null)
            {
                // get parent of the image file
                DirectoryInfo? path = Directory.GetParent(filepath);
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
            if (!saveFileDialog.ShowDialog(this) ?? false)
            {
                return;
            }

            this.StartPDFGeneration(saveFileDialog.FileName);
        }

        private void PdfGenerator_PDFGenerationCompletedEvent(object sender, PDFGenerationCompletedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                // prompt message box to open file
                if (MessageBox.Show(string.Format(Properties.Resources.PDFGenerationCompletedPrompt, e.PDFFilename),
                    Properties.Resources.AppName,
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information,
                    MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    string? directory = Path.GetDirectoryName(e.PDFFilename);
                    if (directory != null)
                    {
                        Process.Start("explorer.exe", directory);
                    }
                }

                this.FinishPDFGeneration();
            });
        }
        private void PdfGenerator_FileProcessedEvent(object sender, FileProcessedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.GeneratorProgressBar.Value = e.Progress;
            });
        }

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
                    this.filenames.Add(file);
                }
            }
            this.FilenameList.Items.Refresh();
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
            this.FilenameList.IsEnabled = false;
            this.GenerateButton.IsEnabled = false;
            this.GeneratorProgressBar.IsEnabled = true;
            this.GeneratorProgressBar.Maximum = this.filenames.Count;

            // create PDF generator
            IPDFGenerator? pdfGenerator = this.pdfGeneratorFactory.CreateFromFiles(this.filenames);
            // TODO: add event handler for progress

            pdfGenerator.PDFGenerationCompletedEvent += this.PdfGenerator_PDFGenerationCompletedEvent;
            pdfGenerator.FileProcessedEvent += this.PdfGenerator_FileProcessedEvent;
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
            this.FilenameList.IsEnabled = true;
            this.GenerateButton.IsEnabled = true;
            this.GeneratorProgressBar.IsEnabled = false;
            this.GeneratorProgressBar.Value = 0;

            // clear file list
            this.filenames.Clear();
            this.FilenameList.Items.Refresh();
        }
    }
}
