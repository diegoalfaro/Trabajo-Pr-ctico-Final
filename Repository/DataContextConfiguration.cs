using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Repository
{
    class DataContextConfiguration : DbConfiguration
    {
        public DataContextConfiguration()
        {
            this.SetDatabaseInitializer(new DropCreateDatabaseAlways<DataContext>());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}