using System;
using System.IO;
using System.Windows;
using Terminal.Contexts;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += (sender, e) =>
            {
                MessageBox.Show(e.Exception.Message);
                e.Handled = true;
            };

            var DataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

            if (!Directory.Exists(DataDirectory)) {
                Directory.CreateDirectory(DataDirectory);
            }
            
            AppDomain.CurrentDomain.SetData("DataDirectory", DataDirectory);
        }
    }
}
