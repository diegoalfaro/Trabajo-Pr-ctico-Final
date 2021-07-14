using Domain;
using System.Data.Entity;

namespace Terminal.Contexts
{
    class DataContext : DbContext
    {
        static DataContext() {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public DataContext() : base("name=Terminal.Properties.Settings.DB_CONNECTION") {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
