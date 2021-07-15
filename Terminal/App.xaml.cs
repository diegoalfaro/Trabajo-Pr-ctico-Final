using Microsoft.Extensions.DependencyInjection;
using RestService;
using Service;
using System;
using System.IO;
using System.Windows;
using Terminal.Helpers;
using Terminal.Pages;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider ServiceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

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

        private void ConfigureServices(IServiceCollection services)
        {
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
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
