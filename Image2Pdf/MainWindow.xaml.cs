namespace Image2Pdf
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using Image2Pdf.Generator;
    using Image2Pdf.Interface;
    using Image2Pdf.Utility;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The factory class of PDF generator.
        /// </summary>
        private readonly PdfGeneratorFactory pdfGeneratorFactory;

        /// <summary>
        /// The filenames of images.
        /// </summary>
        private readonly List<string> filenames;

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
        public MainWindow(PdfGeneratorFactory pdfGeneratorFactory, List<string> filenames)
        {
            this.pdfGeneratorFactory = pdfGeneratorFactory;
            this.filenames = filenames;

            this.InitializeComponent();
            this.FilenameList.ItemsSource = this.filenames;
        }

        #region Commands
        public static readonly RoutedCommand MoveUpCommand = new();
        public static readonly RoutedCommand MoveDownCommand = new();
        public static readonly RoutedCommand RemoveCommand = new();
        public static readonly RoutedCommand GenerateCommand = new();
        #endregion

        #region EventHandlers

        /// <summary>
        /// The event handler of <see cref="MoveUpCommand"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveUpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = this.FilenameList.SelectedIndex;
            (this.filenames[index], this.filenames[index - 1]) = (this.filenames[index - 1], this.filenames[index]);
            this.FilenameList.Items.Refresh();
        }

        /// <summary>
        /// Indicates whether <see cref="MoveUpCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveUpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.SelectedIndex != -1 && this.FilenameList.SelectedIndex > 0;
        }

        /// <summary>
        /// The event handler of <see cref="MoveDownCommand"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveDownCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = this.FilenameList.SelectedIndex;
            (this.filenames[index], this.filenames[index + 1]) = (this.filenames[index + 1], this.filenames[index]);
            this.FilenameList.Items.Refresh();
        }

        /// <summary>
        /// Indicates whether <see cref="MoveDownCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void MoveDownCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.SelectedIndex != -1 && this.FilenameList.SelectedIndex < this.FilenameList.Items.Count - 1;
        }

        /// <summary>
        /// The event handler of <see cref="RemoveCommand"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = this.FilenameList.SelectedIndex;
            this.filenames.RemoveAt(index);
            this.FilenameList.Items.Refresh();
        }

        /// <summary>
        /// Indicates whether <see cref="RemoveCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.SelectedIndex != -1;
        }

        /// <summary>
        /// Indicates whether <see cref="GenerateCommand"/> can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>

        private void GenerateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.FilenameList.Items.Count > 0;
        }

        /// <summary>
        /// The event handler of <see cref="GenerateCommand"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>

        private void GenerateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            // show save file dialog
            SaveFileDialog? saveFileDialog = new();
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

            saveFileDialog.Filter = Properties.Resources.PdfSaveDialogFilter;
            if (!saveFileDialog.ShowDialog(this) ?? false)
            {
                return;
            }

            this.StartPdfGeneration(saveFileDialog.FileName);
        }

        /// <summary>
        /// The event handler of <see cref="IPdfGenerator.PdfGenerationCompletedEvent"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void PdfGenerator_PdfGenerationCompletedEvent(object sender, PdfGenerationCompletedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                // prompt message box to open file
                if (MessageBox.Show(string.Format(Properties.Resources.PdfGenerationCompletedPrompt, e.PdfFilename),
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
        /// The event handler of <see cref="IPdfGenerator.FileProcessedEvent"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The arguments.</param>
        private void PdfGenerator_FileProcessedEvent(object sender, FileProcessedEventArgs e)
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
        private void StartPdfGeneration(string target)
        {
            // disable controls
            this.FilenameList.IsEnabled = false;
            this.GenerateButton.IsEnabled = false;
            this.GeneratorProgressBar.IsEnabled = true;
            this.GeneratorProgressBar.Maximum = this.filenames.Count;

            // create PDF generator
            IPdfGenerator? pdfGenerator = this.pdfGeneratorFactory.AddFiles(this.filenames).Build();

            pdfGenerator.PdfGenerationCompletedEvent += this.PdfGenerator_PdfGenerationCompletedEvent;
            pdfGenerator.FileProcessedEvent += this.PdfGenerator_FileProcessedEvent;
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
