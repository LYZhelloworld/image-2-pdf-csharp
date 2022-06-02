using Image2PDF.PDFGenerator;
using System.Windows;

namespace Image2PDF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var wnd = new MainWindow(new PDFGeneratorFactory());
            wnd.Show();
        }
    }
}
