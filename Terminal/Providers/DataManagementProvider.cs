using DataManagement;
using System;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    class DataManagementProvider : IDataManagementProvider
    {
        public DataManagementProvider()
        {
            DataManager = new DataManager();
        }

        public DataManager DataManager { get; private set; }

        public async Task<TEntity> GetByID<TEntity>(object id) where TEntity : class
        {
            return await DataManager.GetRepository<TEntity>().GetByID(id);
        }

        public async Task Insert<TEntity>(TEntity entity) where TEntity : class
        {
            await DataManager.GetRepository<TEntity>().Insert(entity);
        }

        public async Task Update<TEntity>(TEntity entity) where TEntity : class
        {
            await DataManager.GetRepository<TEntity>().Update(entity);
        }

        public async Task Upsert<TEntity>(TEntity entity) where TEntity : class
        {
            await DataManager.GetRepository<TEntity>().Upsert(entity);
        }

        public async Task Delete<TEntity>(TEntity entity) where TEntity : class
        {
            await DataManager.GetRepository<TEntity>().Delete(entity);
        }

        public async Task SaveAsync()
        {
            await DataManager.SaveAsync();
        }

        public void Dispose()
        {
            DataManager.Dispose();
            DataManager = new DataManager();
        }
    }
}
