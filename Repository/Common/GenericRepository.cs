using System.Collections.Generic;
using System.Data.Entity;

namespace Repository.Common
{
    public class GenericRepository<TContext, TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        internal TContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(TContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll() => dbSet;

        public virtual TEntity GetByID(object id) => dbSet.Find(id);

        public virtual void Insert(TEntity entity) => dbSet.Add(entity);

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Upsert(TEntity entity)
        {
            try {
                Insert(entity);
            } catch {
                Update(entity);
            }
        }

        public virtual void Delete(object id) => Delete(GetByID(id));

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
