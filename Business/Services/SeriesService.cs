using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using Data.Models;

namespace Business.Services
{
    public class SeriesService<T> : ISeriesService<T> where T : Series
    {
        private IMongoRepository<T> _repository;
        public SeriesService(IMongoRepository<T> repository)
        {
            _repository = repository;
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return _repository.FilterBy(filterExpression);
        }

        public T FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Task<T> FindByIdAsync(int id)
        {
            return _repository.FindByIdAsync(id);
        }

        IEnumerable<T> ISeriesService<T>.FindByGenre(string genre)
        {
            return _repository.FilterBy(filter => filter.Genres.ToLower().Contains(genre.ToLower()));
        }

        IEnumerable<T> ISeriesService<T>.FindByName(string name)
        {
            return _repository.FilterBy(filter => filter.OriginalName.ToLower().Contains(name.ToLower()));

        }

        public void InsertMany(ICollection<T> documents)
        {
            _repository.InsertMany(documents);
        }

        public void InsertOne(T document)
        {
            _repository.InsertOne(document);
        }

        public async Task InsertOneAsync(T document)
        {
            await _repository.InsertOneAsync(document);
        }

        public void ReplaceOne(T document)
        {
            _repository.ReplaceOne(document);
        }

        public async Task ReplaceOneAsync(T document)
        {
            await _repository.ReplaceOneAsync(document);
        }


    }
}