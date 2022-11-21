using AutoMapper;
using Movies.API.Application.Movie.Commmand;
using Movies.API.Application.Movie.Dto;

namespace Movies.API.Application.Movie.Mapper;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<AddMovieCommand, Domain.Entity.Movies>();
        CreateMap<AddMovieDto, AddMovieCommand>();
    }
}