using System;
using System.IO;
using System.Windows;
using static Terminal.Properties.Settings;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        AppServiceProvider AppServiceProvider;

        public App()
        {
            ConfigureExceptionHandler();
            ConfigureDataDirectory();
            AppServiceProvider = new AppServiceProvider();
        }

        private void ConfigureExceptionHandler()
        {
            this.DispatcherUnhandledException += (sender, e) =>
            {
                MessageBox.Show(e.Exception.Message);
                e.Handled = true;
            };
        }

        private void ConfigureDataDirectory()
        {
            var DataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Default.DATA_DIRECTORY);

            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }

            AppDomain.CurrentDomain.SetData(Default.DATA_DIRECTORY_KEY, DataDirectory);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = AppServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
