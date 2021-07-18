using Domain;
using System.Data.Entity;
using static DataManagement.Properties.Settings;

namespace DataManagement.Context
{
    [DbConfigurationType(typeof(DataContextConfiguration))]
    public class DataContext : DbContext
    {
        public DataContext() : base(Default.CONNECTION_STRING) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UserAction> UserActions { get; set; }
    }
}
