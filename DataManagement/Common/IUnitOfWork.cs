using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataManagement.Common
{
    interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        Task<int> SaveAsync();
    }
}
