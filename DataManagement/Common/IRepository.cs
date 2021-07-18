using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataManagement.Common
{
    public interface IRepository<TContext, TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetByID(object id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Upsert(TEntity entity);
        void Delete(object id);
        Task Delete(TEntity entity);
        object GetPrimaryKey(TEntity entity);
        Task<TEntity> GetEntity(TEntity entity);
    }
}
