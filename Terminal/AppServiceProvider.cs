using System;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Pages;
using Terminal.Providers;
using Services;
using RestService;

namespace Terminal
{
    public class AppServiceProvider
    {
        private readonly IServiceProvider ServiceProvider;

        public AppServiceProvider()
        {
            ServiceProvider = CreateServiceProvider();
        }

        private static ServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IAuthService, ApiRestService>();
            services.AddSingleton<IClientService, ApiRestService>();
            services.AddSingleton<IAccountService, ApiRestService>();
            services.AddSingleton<IProductService, ApiRestService>();

            services.AddSingleton<INavigationProvider, NavigationProvider>();
            services.AddSingleton<IDataManagementProvider, DataManagementProvider>();
            services.AddSingleton<IAuthProvider, AuthProvider>();
            services.AddSingleton<IUserActionProvider, UserActionProvider>();
            services.AddSingleton<IAccountProvider, AccountProvider>();
            services.AddSingleton<IProductProvider, ProductProvider>();

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

        public TService GetRequiredService<TService>() => ServiceProvider.GetRequiredService<TService>();
    }
}
