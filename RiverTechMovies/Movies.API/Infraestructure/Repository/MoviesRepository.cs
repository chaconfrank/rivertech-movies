namespace Movies.API.Infraestructure.Repository;

using Movies.API.Domain.Repository;
using Domain.Entity;
public class MoviesRepository : BaseRepository<Movie, Context>, IMoviesRepository
{
    public MoviesRepository(Context context) : base(context)
    {
    }
}