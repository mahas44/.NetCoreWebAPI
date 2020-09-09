using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using Data.Models;

namespace Business.Services
{
    public class MovieService<T> : IMovieService<T> where T : Movie
    {
        private IMongoRepository<T> _repository;
        public MovieService(IMongoRepository<T> repository)
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

        public IEnumerable<T> FindByGenre(string genre)
        {
           
            return _repository.FilterBy(filter => filter.Genres.ToLower().Contains(genre.ToLower())); 
        }

        public T FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Task<T> FindByIdAsync(int id)
        {
            return _repository.FindByIdAsync(id);
        }

        public IEnumerable<T> FindByReleaseDate(string date)
        {
            List<T> result = new List<T>();
            IEnumerable<T> data = _repository.FilterBy(filter => filter.Title != "");
            long dateTime = DateTimeOffset.Parse(date).ToUnixTimeSeconds();
            foreach (var item in data)
            {
                long movieDate = DateTimeOffset.Parse(item.ReleaseDate).ToUnixTimeSeconds();
                if( movieDate >= dateTime) {
                    result.Add(item);
                }
            }
            return result;
        }

        public IEnumerable<T> FindByTitle(string title)
        {
            return _repository.FilterBy(filter => filter.Title.ToLower().Contains(title.ToLower()));
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