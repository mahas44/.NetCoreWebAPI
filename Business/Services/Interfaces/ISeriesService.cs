using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Data.Models;

namespace Business.Services.Interfaces
{
    public interface ISeriesService<T> : IGenericService<T> where T : Series
    {
        IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> FindByName(string name);

        IEnumerable<T> FindByGenre(string genre);

    }
}