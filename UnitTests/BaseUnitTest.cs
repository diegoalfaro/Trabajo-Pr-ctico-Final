using RestService;
using Services;
using System;
using System.IO;
using Terminal.Providers;
using static UnitTests.Properties.Settings;

namespace UnitTests
{
    public abstract class BaseUnitTest
    {
        protected IAuthService AuthService;
        protected IProductService ProductService;
        protected IClientService ClientService;
        protected IAccountService AccountService;

        protected IDataManagementProvider DataManagementProvider;
        protected IAuthProvider AuthProvider;
        protected IUserActionProvider UserActionProvider;
        protected IProductProvider ProductProvider;
        protected IAccountProvider AccountProvider;

        public BaseUnitTest()
        {
            ConfigureDataDirectory();
            ConfigureDependencies();
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

        private void ConfigureDependencies()
        {
            var apiService = new ApiRestService();
            AuthService = apiService;
            ProductService = apiService;
            ClientService = apiService;
            AccountService = apiService;

            DataManagementProvider = new DataManagementProvider();
            AuthProvider = new AuthProvider(AuthService, DataManagementProvider);
            UserActionProvider = new UserActionProvider(AuthProvider, DataManagementProvider);
            ProductProvider = new ProductProvider(ProductService, AuthProvider, UserActionProvider);
            AccountProvider = new AccountProvider(AccountService, AuthProvider, UserActionProvider);
        }
    }
}
