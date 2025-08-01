using AccessControl.Core.Entities;
using System.Linq.Expressions;

namespace AccessControl.Core.Base.Repositories.Interface
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetListAsync();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> GetByIdAsNoTracking(Guid id);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Create(TEntity objeto);
        Task<bool> Update(TEntity objeto);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
