using Movies.Domain.Repository;

namespace Movies.Infraestructure.Repository;

public class MoviesRepository : BaseRepository<Domain.Entity.Movies, Context>, IMoviesRepository
{
    public MoviesRepository(Context context) : base(context)
    {
    }
}