namespace Movies.API.Application.Movie.Dto;

public class UpdateMovieDto
{
    public string? Id { get; set; }
    public string? Key { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Rate { get; set; }
    public string? Length { get; set; }
    public string? Img { get; set; }
    public List<GenreDto> Geners { get; set; }
}