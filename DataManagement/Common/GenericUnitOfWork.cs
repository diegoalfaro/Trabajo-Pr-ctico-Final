using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataManagement.Common
{
    public abstract class GenericUnitOfWork<TContext>: IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        public bool Disposed = false;
        protected readonly TContext Context;

        public GenericUnitOfWork()
        {
            this.Context = new TContext();
        }

        public IRepository<TContext, TEntity> GetRepository<TEntity>() where TEntity : class => new Repository<TContext, TEntity>(Context);

        public async Task<int> SaveAsync() => await this.Context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
            }

            this.Disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
