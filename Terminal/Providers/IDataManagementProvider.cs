using System;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public interface IDataManagementProvider: IDisposable
    {
        Task<TEntity> GetByID<TEntity>(object id) where TEntity : class;
        Task Insert<TEntity>(TEntity entity) where TEntity : class;
        Task Update<TEntity>(TEntity entity) where TEntity : class;
        Task Upsert<TEntity>(TEntity entity) where TEntity : class;
        Task Delete<TEntity>(TEntity entity) where TEntity : class;
        Task SaveAsync();
    }
}
