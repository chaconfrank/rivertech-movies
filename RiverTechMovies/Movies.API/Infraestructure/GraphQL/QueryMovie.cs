using HotChocolate.Data;
using MongoDB.Driver;
using Movies.API.Domain.Entity;

namespace Movies.API.Infraestructure.GraphQL;

public class QueryMovie
{
    [UsePaging]
    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IExecutable<Movie> GetMovies(
        [Service] IMongoCollection<Movie> collection)
        => collection.AsExecutable();

    [UseFirstOrDefault]
    public IExecutable<Movie> GetMovieById(
        [Service] IMongoCollection<Movie> collection,
        [ID] String id)
        => collection.Find(x => x._id == id).AsExecutable();
    
}