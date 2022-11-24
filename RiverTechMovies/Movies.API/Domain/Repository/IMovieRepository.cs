using Movies.API.Domain.Entity;

namespace Movies.API.Domain.Repository;

public interface IMovieRepository
{
    Task<Movie> GetById(string id);
    Task<List<Movie>> GetAll();
    Task<Movie> Add(Movie movie);
    Task<Movie> Update(Movie movie);
}