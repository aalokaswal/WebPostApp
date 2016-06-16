using System;
using System.IO;
using System.Windows;

namespace WebPosts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
          
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var errorMessage = string.Format("An exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\errorLog.txt", e.Exception.StackTrace);
            e.Handled = true;
        }
    }
}

