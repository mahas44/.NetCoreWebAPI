using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Models;

namespace Business.Services.Interfaces
{
    public interface IMongoRepository<T> where T : Base
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression);
        
        IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TProjected>> projectionExpression);

        T FindOne(Expression<Func<T, bool>> filterExpression);

        Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);

        T FindById(int id);

        Task<T> FindByIdAsync(int id);

        void InsertOne(T document);

        Task InsertOneAsync(T document);

        void InsertMany(ICollection<T> documents);

        Task InsertManyAsync(ICollection<T> documents);

        void ReplaceOne(T document);

        Task ReplaceOneAsync(T document);

        void DeleteOne(Expression<Func<T, bool>> filterExpression);

        Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression);

        void DeleteById(int id);

        Task DeleteByIdAsync(int id);

        void DeleteMany(Expression<Func<T, bool>> filterExpression);

        Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
    }
}