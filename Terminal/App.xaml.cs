using Microsoft.Extensions.DependencyInjection;
using RestService;
using Service;
using System;
using System.IO;
using System.Windows;
using Terminal.Helpers;
using Terminal.Pages;
using static Terminal.Properties.Settings;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        const string DATA_DIRECTORY_KEY = "DataDirectory";

        private readonly ServiceProvider ServiceProvider;

        private static ServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IApiService>(new ApiRestService());

            services.AddSingleton<NavigationHelper>();
            services.AddSingleton<AuthHelper>();
            services.AddSingleton<ProductHelper>();
            services.AddSingleton<AccountHelper>();

            services.AddTransient<MainWindow>();
            services.AddTransient<Balance>();
            services.AddTransient<Error>();
            services.AddTransient<Loading>();
            services.AddTransient<Login>();
            services.AddTransient<Main>();
            services.AddTransient<Movements>();
            services.AddTransient<ProductReset>();
            services.AddTransient<ProductResetResult>();

            return services.BuildServiceProvider();
        }

        public App()
        {
            ConfigureExceptionHandler();
            ConfigureDataDirectory();
            ServiceProvider = CreateServiceProvider();
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

            AppDomain.CurrentDomain.SetData(DATA_DIRECTORY_KEY, DataDirectory);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
