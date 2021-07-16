using Domain;
using Repository.Common;

namespace Repository
{
    public class DataUnitOfWork: GenericUnitOfWork<DataContext>
    {
        public readonly GenericRepository<DataContext, Client> ClientRepository;
        public readonly GenericRepository<DataContext, Session> SessionRepository;

        public DataUnitOfWork() : base()
        {
            this.ClientRepository = new GenericRepository<DataContext, Client>(this.Context);
            this.SessionRepository = new GenericRepository<DataContext, Session>(this.Context);
        }
    }
}
