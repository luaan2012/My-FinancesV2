using Finances.Domain.IRepository;
using Finances.Identity;
using Finances.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finances.Domain.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(ApplicationDbContext db)
        {
            _dbContext = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> ObterId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
