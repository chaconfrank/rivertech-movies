using Movies.API.Domain.Repository;
using Movies.Infraestructure.Repository;

namespace Movies.API.Infraestructure.Repository;

public class MoviesRepository : BaseRepository<API.Domain.Entity.Movies, Context>, IMoviesRepository
{
    public MoviesRepository(Context context) : base(context)
    {
    }
}