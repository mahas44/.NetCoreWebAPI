using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using Data.Attributes;
using Data.Configuration;
using Data.Models;
using MongoDB.Driver;

namespace Business.Services
{
    public class MongoRepository<T> : IMongoRepository<T> where T : Base
    {
        private readonly MongoDB.Driver.IMongoCollection<T> _collection;

        public MongoRepository(IDatabaseSettings settings)
        {
            var db = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        /*
            this method uses our previously prepared attribute and 
            gets documents collection by type of document provided in parameter 
        */
        private protected string GetCollectionName(Type type)
        {
            return ((BsonCollectionAttribute)type.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        /*
            this method let’s us to get whole non-materialized collection and 
            perform some operations later 
            (it’s slower than other methods because adds extra abstraction layer)
        */
        public IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        /*
            DeleteOne and DeleteById: those are for hard-deleting documents in our app. 
            When it comes to business application, i’d also suggest you using soft-delete, 
            by simply updating some field called documentState and setting it to deleted. 
            It’ll secure your data from being deleted by accident or some other cases.
        */
        public void DeleteById(int id)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
            _collection.FindOneAndDelete(filter);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Task.Run(() =>
            {
                var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<T, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public async Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            await Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }

        public void DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public async Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            await Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        /* 
            FilterBy : those methods allows us to filter data by sending expressions in parameters. 
            This works similar to LINQ, but operations are performed on database, 
            so it’s much faster than doing it later in code-side. 
            I provided extra parameter called projectionExpression, this parameter is useful, 
            when you want to get only some fields, rather than full objects from filtered results. 
            You can also add sorting when necessary, simply using Sort method provided by IFindFluent interface.
        */
        public IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).SortBy(filter => filter.Id).ToEnumerable();
        }

        public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        /*
            FindOne and FindById : those methods are here to get single objects from database,
            I provided here also asynchronous implementations.
        */
        public T FindById(int id)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
            return _collection.Find(filter).SingleOrDefault();
        }

        public Task<T> FindByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
                return _collection.Find(filter).SingleOrDefault();
            });
        }

        public T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        /*
            InsertOne and InsertMany: methods are used to insert documents to our database,
            also implemented in synchronous and asynchronous ways.
        */
        public void InsertMany(ICollection<T> documents)
        {
            _collection.InsertMany(documents);
        }

        public async Task InsertManyAsync(ICollection<T> documents)
        {
            await Task.Run(() => _collection.InsertManyAsync(documents));
        }

        public void InsertOne(T document)
        {
            _collection.InsertOne(document);
        }

        public async Task InsertOneAsync(T document)
        {
            await Task.Run(() => _collection.InsertOneAsync(document));
        }

        /*
            ReplaceOne: this method is used to replace documents in our application. 
            You can also use Update method if you need.
        */
        public void ReplaceOne(T document)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public async Task ReplaceOneAsync(T document)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, document.Id);
            await Task.Run(() => _collection.FindOneAndReplaceAsync(filter, document));
        }

    }
}