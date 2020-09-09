using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Data.Models;

namespace Business.Services.Interfaces
{
    public interface IMovieService<T>: IGenericService<T> where T: Movie
    {
        IEnumerable<T> FilterBy(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> FindByTitle(string name);

        IEnumerable<T> FindByGenre(string genre);

        IEnumerable<T> FindByReleaseDate(string date);
        
    }
}