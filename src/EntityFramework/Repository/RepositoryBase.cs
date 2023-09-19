using BE_Event_Project.Entities;
using BE_Event_Project.EntityFramework;
using BE_Event_Project.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> _dbSet;

        public RepositoryBase(AppDbContext db)
        {
            _dbSet = db.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.Id = new Guid();
            entity.CreationTime = DateTime.Now;
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public void Update(TEntity entity)
        {
            entity.LastModificationTime = DateTime.Now;
            _dbSet.Update(entity);
        }

        public void DeleteAsync(TEntity entity, bool softDelete = true) 
        {
            if(softDelete)
            {
                entity.IsDeleted = true;
                entity.LastModificationTime = DateTime.Now;
                return;
            }

            _dbSet.Remove(entity);
        }

        public async Task<long> CountAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}
