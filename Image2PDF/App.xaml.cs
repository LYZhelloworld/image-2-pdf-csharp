namespace Image2PDF
{
    using System.Windows;
    using Image2PDF.PDFGenerator;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow? wnd = new MainWindow(new PDFGeneratorFactory());
            wnd.Show();
        }
    }
}
