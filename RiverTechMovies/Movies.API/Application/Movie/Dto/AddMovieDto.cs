namespace Movies.API.Application.Movie.Dto;

public class AddMovieDto
{
    public string? Key { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Rate { get; set; }
    public string? Length { get; set; }
    public string? Img { get; set; }
}