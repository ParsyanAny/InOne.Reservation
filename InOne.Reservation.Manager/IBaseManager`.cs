using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InOne.Reservation.Manager
{
    public interface IBaseManager<TModel>
    {
        bool Any(Expression<Func<TModel, bool>> predicate);
        void Add(TModel model);
        void Delete(TModel model);
        void DeleteById(int Id);
        void DeleteRange(IEnumerable<TModel> models);
        TModel GetModel(int Id);
        IEnumerable<TModel> GetModels();
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> predicate);
        void SaveChanges();
    }
}
