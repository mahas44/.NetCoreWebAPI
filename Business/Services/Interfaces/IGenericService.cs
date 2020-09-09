using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IGenericService<T> where T : Base
    {
        T FindById(int id);

        Task<T> FindByIdAsync(int id);

        void InsertOne(T document);

        Task InsertOneAsync(T document);

        void InsertMany(ICollection<T> documents);

        void ReplaceOne(T document);

        Task ReplaceOneAsync(T document);

        void DeleteById(int id);

    }
}