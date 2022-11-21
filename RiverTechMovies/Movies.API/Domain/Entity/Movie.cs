namespace Movies.API.Domain.Entity;

public class Movie
{
    public long Id { get; set; }
    public string? Key { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Rate { get; set; }
    public string? Length { get; set; }
    public string? Img { get; set; }
}