namespace Movies.API.Application.Movie.Query;

using Domain.Entity;
using MediatR;


public class GetAllMoviesQuery : IRequest<List<Movie>>
{
    
}