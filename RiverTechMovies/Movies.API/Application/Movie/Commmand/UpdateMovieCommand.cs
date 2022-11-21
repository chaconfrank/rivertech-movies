namespace Movies.API.Application.Movie.Commmand;

using MediatR;
using Domain.Entity;


public class UpdateMovieCommand : IRequest<Movie>
{
    public Movie movie { get; set; }
    public string? Key { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Rate { get; set; }
    public string? Length { get; set; }
    public string? Img { get; set; }
}