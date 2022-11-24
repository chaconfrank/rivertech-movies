using MongoDB.Bson;
using MongoDB.Driver;
using Movies.API.Domain.Context;
using Movies.API.Domain.Entity;
using Movies.API.Domain.Repository;
using Movies.API.Infraestructure.Controller.Router;

namespace Movies.API.Infraestructure.Repository;

public class MovieRepository: IMovieRepository
{
    private readonly ICatalogContext _context;

    public MovieRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<Movie> GetById(string id)
    {
        var filter = Builders<Movie>.Filter.Eq(_ => _._id, id);
        return await _context.Movies.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Movie> Add(Movie movie)
    {
        _context.Movies.InsertOne(movie);
        return await Task.Run(() => movie);
    }

    public async Task<Movie> Update(Movie movie)
    {
        _context.Movies.ReplaceOne(item => item._id.Equals(movie._id), movie);
        return await Task.Run(() => movie);
    }

    public async Task<List<Movie>> GetAll()
    {
        return _context.Movies.Find(Builders<Movie>.Filter.Empty).ToList();
    }
}