using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace DataManagement.Context
{
    public class DataContextConfiguration : DbConfiguration
    {
        public DataContextConfiguration()
        {
            this.SetDatabaseInitializer(new CreateDatabaseIfNotExists<DataContext>());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}