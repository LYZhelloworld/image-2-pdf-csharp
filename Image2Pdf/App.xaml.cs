using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Image2Pdf;

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
        MainWindow wnd = new();
        wnd.Show();
    }
}
