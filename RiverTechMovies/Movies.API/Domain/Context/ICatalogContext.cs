using MongoDB.Driver;
using Movies.API.Domain.Entity;

namespace Movies.API.Domain.Context;

public interface ICatalogContext
{
     IMongoCollection<Movie> Movies { get; }
}