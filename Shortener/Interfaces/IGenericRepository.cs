using System.Linq.Expressions;

namespace Shortener.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity FindById(Guid Id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
        void Remove(Guid Id);
        void RemoveRange(IEnumerable<TEntity> items);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        void Save();
    }
}
