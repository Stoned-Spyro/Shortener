using Microsoft.EntityFrameworkCore;
using Shortener.Data;
using Shortener.Interfaces;
using System.Linq.Expressions;

namespace Shortener.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ShortenerDBContext context;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(ShortenerDBContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity? FindById(Guid Id)
        {
            return dbSet.Find(Id);
        }

        public virtual void Create(TEntity item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }


        public virtual void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Remove(TEntity item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            dbSet.RemoveRange(items);
            context.SaveChanges();
        }

        public virtual void Remove(Guid Id)
        {
            TEntity? entity = FindById(Id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
