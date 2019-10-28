using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InOne.Reservation.Manager
{
    public interface IDtoManager<TModel, TDto>
    {
        void Add(TDto dto);
        TDto GetDto(int Id);
        IEnumerable<TDto> GetDtos();
        IEnumerable<TDto> GetDtos(Expression<Func<TModel, bool>> predicate);
    }
}
