using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using InOne.Reservation.Repository.Interfaces;

namespace InOne.Reservation.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        protected readonly DbContext _context;
        protected BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }
        #region Actions
        public void DeleteById(int id)
        {
            try
            {
                TEntity entityToRemove = GetById(id);
                Delete(entityToRemove);
            }
            catch (Exception)
            {
            }
        }
        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);
        public void DeleteRange(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().RemoveRange(entities);
        #endregion

        #region ReadOnly
        public bool Any(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Any(predicate);
        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id);
        public Task<TEntity> GetByIdAsync(int id)
            => _context.Set<TEntity>().FindAsync(id);
        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>();
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Where(predicate);
        #endregion;

        public void SaveChanges() => _context.SaveChanges();
        public Task SaveChangesAsync()
            => _context.SaveChangesAsync();
    }
}