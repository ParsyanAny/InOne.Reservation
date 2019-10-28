using InOne.Reservation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InOne.Reservation.Manager.IMPL
{
    public class BaseManager<TModel> : IBaseManager<TModel>
        where TModel : class
    {
        protected readonly ApplicationContext _context;
        protected BaseManager(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(TModel model) => _context.Set<TModel>().Add(model);
        public bool Any(Expression<Func<TModel, bool>> predicate) => _context.Set<TModel>().Any(predicate);
        public void Delete(TModel model) => _context.Set<TModel>().Remove(model);
        public void DeleteById(int Id) => Delete(_context.Set<TModel>().Find(Id));
        public void DeleteRange(IEnumerable<TModel> models)
            => _context.Set<TModel>().RemoveRange(models);
        public TModel GetModel(int Id) => _context.Set<TModel>().Find(Id);
        public IEnumerable<TModel> GetModels() => _context.Set<TModel>();
        public IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> predicate)
            => _context.Set<TModel>().Where(predicate);
        public void SaveChanges() => _context.SaveChanges();
    }
}
