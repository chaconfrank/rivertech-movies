using MongoDB.Driver;
using Movies.API.Domain.Entity;

namespace Movies.API.Infraestructure.GraphQL;

public class MovieResolver
{
    public Task<Movie> ResolveAsync(
        [Service] IMongoCollection<Movie> collection,
        String id)
    {
        return collection.Find(x => x._id == id).FirstOrDefaultAsync();
    }
}