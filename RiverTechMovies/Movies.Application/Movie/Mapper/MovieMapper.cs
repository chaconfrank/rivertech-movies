using AutoMapper;
using Movies.Application.Movie.Commmand;
using Movies.Application.Movie.Dto;

namespace Movies.Application.Movie.Mapper;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<AddMovieCommand, Domain.Entity.Movies>();
        CreateMap<AddMovieDto, AddMovieCommand>();
    }
}