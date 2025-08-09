using AccessControl.Core.Base.Repositories.Interface;
using AccessControl.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccessControl.Core.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;
        protected readonly long ContaId;

        public RepositoryBase(DbContext context, IUser user)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            ContaId = user.GetAccountId();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate) => await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate).ToListAsync();

        public virtual async Task<IQueryable<TEntity>> GetListAsync() => await Task.FromResult(_dbSet.Where(c => c.ContaId == ContaId).AsQueryable());

        public virtual async Task<TEntity> GetById(Guid id) => await _dbSet.FindAsync(id);
        public virtual async Task<TEntity> GetByIdAsNoTracking(Guid id) => await _dbSet.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(e => e.Id.Equals(id));

        public virtual async Task<bool> Create(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            _dbSet.Add(entity);
            return await SaveChanges() > 0;
        }
        public virtual async Task<bool> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return await SaveChanges() > 0;
        }
        public virtual async Task<bool> AtualizarLista(List<TEntity> entities)
        {
            entities.ForEach(entity => _context.Entry(entity).State = EntityState.Modified);

            return await SaveChanges() > 0;
        }
        public virtual async Task Delete(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

        public void Dispose() =>
       _context?.Dispose();
    }
}
