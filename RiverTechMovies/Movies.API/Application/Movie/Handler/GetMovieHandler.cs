using System.Net;
using Movies.API.Domain.Config;

namespace Movies.API.Application.Movie.Handler;

using MediatR;
using Query;
using Domain.Repository;
using Domain.Entity;

public class GetMovieHandler : IRequestHandler<GetMovieQuery, Movie>
{
    private readonly IMovieRepository _repository;

    public GetMovieHandler(IMovieRepository repository)
    {
        _repository = repository;
    }

    public Task<Movie> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        Task<Movie> movie = _repository.GetById(request.id.ToString());
        
        if (movie.Result == null)
            throw new ApiException(HttpStatusCode.NotFound, "Movie is not found");
        
        return movie;
    }
}