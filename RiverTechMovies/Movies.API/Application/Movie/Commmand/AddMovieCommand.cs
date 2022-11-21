using MediatR;

namespace Movies.API.Application.Movie.Commmand;

public class AddMovieCommand : IRequest<Domain.Entity.Movies>
{
    public string? Key { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Rate { get; set; }
    public string? Length { get; set; }
    public string? Img { get; set; }
}