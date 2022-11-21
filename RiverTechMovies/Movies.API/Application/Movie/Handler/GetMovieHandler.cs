namespace Movies.API.Application.Movie.Handler;

using System.Net;
using MediatR;
using Query;
using Domain.Config;
using Domain.Repository;
using Domain.Entity;

public class GetMovieHandler : IRequestHandler<GetMovieQuery, Movie>
{
    private readonly IMoviesRepository _repository;

    public GetMovieHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }

    public Task<Movie> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        Task<Movie> movie = _repository.GetAsync(request.id);
        
        if (movie.Result == null)
            throw new ApiException(HttpStatusCode.NotFound, "Movie is not found");
        
        return movie;    
    }
}