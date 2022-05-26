﻿using System.Collections.Generic;
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
            filenameList.ItemsSource = filenames;

            // test data
            filenames.Add("File 1 File 1 File 1 File 1 File 1 File 1 File 1 File 1 File 1");
            filenames.Add("File 2 File 1 File 1 File 1 File 1 File 1 File 1 File 1 File 1");
            filenames.Add("File 3 File 1 File 1 File 1 File 1 File 1 File 1 File 1 File 1");

        }

        private void MoveUpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var index = filenameList.SelectedIndex;
            (filenames[index], filenames[index-1]) = (filenames[index-1], filenames[index]);
            filenameList.Items.Refresh();
        }

        private void MoveUpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = filenameList.SelectedIndex != -1 && filenameList.SelectedIndex > 0;
        }

        private void MoveDownCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var index = filenameList.SelectedIndex;
            (filenames[index], filenames[index + 1]) = (filenames[index + 1], filenames[index]);
            filenameList.Items.Refresh();
        }

        private void MoveDownCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = filenameList.SelectedIndex != -1 && filenameList.SelectedIndex < filenameList.Items.Count - 1;
        }

        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var index = filenameList.SelectedIndex;
            filenames.RemoveAt(index);
            filenameList.Items.Refresh();
        }

        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = filenameList.SelectedIndex != -1;
        }
    }
}
