namespace Movies.API.Application.Movie.Query;

using MediatR;
using Domain.Entity;

public class GetMovieQuery : IRequest<Movie>
{
    public long id { get; set; }
}