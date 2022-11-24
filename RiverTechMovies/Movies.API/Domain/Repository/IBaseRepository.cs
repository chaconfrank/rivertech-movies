using MongoDB.Bson;
using Movies.API.Domain.Entity;

namespace Movies.API.Domain.Repository;

public interface IBaseRepository<TDocument> where TDocument : IDocument 
{
    Task<TDocument> AddAsync(TDocument entity);
    Task<TDocument> UpdateAsync(TDocument entity);
    Task<TDocument> GetAsync(ObjectId id);
    Task<IEnumerable<Movie>> GetAllAsync();
}