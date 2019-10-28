using InOne.Reservation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InOne.Reservation.Manager.IMPL
{
    public abstract class BaseManager<TModel, TDto> : IBaseManager<TModel, TDto>
        where TModel : class
    {
        protected readonly ApplicationContext _context;
        protected BaseManager(ApplicationContext context)
        {
            _context = context;
        }

        public abstract TDto ModelToDto(TModel model);
        public abstract TModel DtoToModel(TDto dto);

        public void Add(TDto dto) => _context.Set<TModel>().Add(DtoToModel(dto));
        public bool Any(Expression<Func<TModel, bool>> predicate) => _context.Set<TModel>().Any(predicate);
        public void Delete(TModel model) => _context.Set<TModel>().Remove(model);
        public void DeleteById(int Id) => Delete(_context.Set<TModel>().Find(Id));
        public void DeleteRange(IEnumerable<TModel> models)
            => _context.Set<TModel>().RemoveRange(models);
        public TModel GetModel(int Id) => _context.Set<TModel>().Find(Id);
        public TDto GetDto(int Id) => ModelToDto(_context.Set<TModel>().Find(Id));
        public IEnumerable<TModel> GetModels() => _context.Set<TModel>();
        public IEnumerable<TDto> GetDtos()
        {
            var models = _context.Set<TModel>();
            foreach (var item in models)
                yield return ModelToDto(item);
        }
        public IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> predicate)
            => _context.Set<TModel>().Where(predicate);
        public IEnumerable<TDto> GetDtos(Expression<Func<TModel, bool>> predicate)
        {
            var models = _context.Set<TModel>().Where(predicate);
            foreach (var item in models)
            {
                yield return ModelToDto(item);
            }
        }
        public void SaveChanges() => _context.SaveChanges();
    }
}
