using Domain;
using System.Data.Entity;
using static Repository.Properties.Settings;

namespace Repository
{
    [DbConfigurationType(typeof(DataContextConfiguration))]
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        public DataContext() : base(Default.CONNECTION_STRING) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
