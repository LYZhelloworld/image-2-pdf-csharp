﻿// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class App : Application
    {
        /// <summary>
        /// The startup event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The startup event arguments.</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new ();
            wnd.Show();
        }
    }
}
