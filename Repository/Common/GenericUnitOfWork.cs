using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Repository.Common
{
    public class GenericUnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        private bool Disposed = false;
        protected readonly TContext Context;

        public GenericUnitOfWork()
        {
            this.Context = new TContext();
        }

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
