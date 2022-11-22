using Movies.API.Domain.Entity;

namespace Movies.API.Infraestructure.GraphQL;

public class QueryMovie
{
    public IQueryable<Movie> GetMovies([Service] Context context) =>
        context.Movies;
}