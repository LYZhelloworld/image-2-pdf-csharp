// <copyright file="App.xaml.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Image2Pdf.Adapters;
    using Image2Pdf.Generators;
    using Image2Pdf.Models;
    using Image2Pdf.Wrappers;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class App : Application
    {
        /// <summary>
        /// Registers services and get <see cref="ServiceProvider"/> instance.
        /// </summary>
        /// <returns>The <see cref="ServiceProvider"/> instance with services registered.</returns>
        private static ServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            // Adapters
            serviceCollection.AddScoped<IPdfAdapterFactory, PdfAdapterFactory>();

            // Generators
            serviceCollection.AddScoped<IPdfGeneratorFactory, PdfGeneratorFactory>();

            // Models
            serviceCollection.AddScoped<IMainWindowModel, MainWindowModel>();

            // Wrappers
            serviceCollection.AddSingleton<IPdfWrapper, PdfWrapper>();
            serviceCollection.AddSingleton<ISystemIOWrapper, SystemIOWrapper>();
            serviceCollection.AddSingleton<ISystemDrawingWrapper, SystemDrawingWrapper>();

            // MainWindow
            serviceCollection.AddScoped<MainWindow>();

            return serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// The startup event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The startup event arguments.</param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var serviceProvider = BuildServiceProvider();

            var wnd = serviceProvider.GetService<MainWindow>()!;
            wnd.Show();
        }
    }
}
