namespace Movies.API.Application.Movie.Mapper;

using AutoMapper;
using Commmand;
using Dto;
using Domain.Entity;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<AddMovieCommand, Movie>();
        CreateMap<AddMovieDto, AddMovieCommand>();

        CreateMap<UpdateMovieDto, UpdateMovieCommand>();
    }
}