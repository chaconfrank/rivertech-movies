using MongoDB.Bson;
using MongoDB.Driver;
using Movies.API.Domain.Config;
using Movies.API.Domain.Entity;
using Orleans;
using Orleans.Runtime;

namespace Movies.API.Infraestructure.Repository;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Movies.API.Domain.Repository;

public class BaseRepository<TDocument> : IBaseRepository<TDocument>
    where TDocument : IDocument
{
    
    private readonly IMongoCollection<TDocument> _collection;

    public BaseRepository(DatabaseSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        //_collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }


    public Task<TDocument> AddAsync(TDocument entity)
    {
        return (Task<TDocument>)Task.Run(() => _collection.InsertOneAsync(entity));
    }

    public Task<TDocument> UpdateAsync(TDocument entity)
    {
        throw new NotImplementedException();
    }

    public async Task<TDocument> GetAsync(ObjectId id)
    {
        var filter = Builders<TDocument>.Filter.Eq<>(doc => doc.Id, id);
        return _collection.Find(filter).SingleOrDefault();
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
    
    /*
    private protected string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute) documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault())?.CollectionName;
    }
    */
}