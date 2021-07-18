using System;
using System.IO;
using Terminal;
using Terminal.Providers;
using static UnitTests.Properties.Settings;

namespace UnitTests.Common
{
    public abstract class BaseUnitTest
    {
        AppServiceProvider AppServiceProvider;

        protected IDataManagementProvider DataManagementProvider;
        protected IAuthProvider AuthProvider;
        protected IUserActionProvider UserActionProvider;
        protected IProductProvider ProductProvider;
        protected IAccountProvider AccountProvider;

        public BaseUnitTest()
        {
            AppServiceProvider = new AppServiceProvider();

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
            DataManagementProvider = AppServiceProvider.GetRequiredService<IDataManagementProvider>();
            AuthProvider = AppServiceProvider.GetRequiredService<IAuthProvider>();
            UserActionProvider = AppServiceProvider.GetRequiredService<IUserActionProvider>();
            ProductProvider = AppServiceProvider.GetRequiredService<IProductProvider>();
            AccountProvider = AppServiceProvider.GetRequiredService<IAccountProvider>();
        }
    }
}
