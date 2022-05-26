using System.Collections.Generic;
using System.Linq;
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

        #region Commands
        public static readonly RoutedCommand MoveUpCommand = new();
        public static readonly RoutedCommand MoveDownCommand = new();
        public static readonly RoutedCommand RemoveCommand = new();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            filenames = new List<string>();
            FilenameList.ItemsSource = filenames;
        }

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
