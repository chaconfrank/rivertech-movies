namespace Movies.API.Application.Movie.Handler;

using Domain.Repository;
using Query;
using Domain.Entity;
using MediatR;

public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, List<Movie>>
{
    private readonly IMovieRepository _repository;

    public GetAllMoviesHandler(IMovieRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAll();
    }
}