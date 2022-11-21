namespace Movies.API.Application.Movie.Handler;

using AutoMapper;
using MediatR;
using Commmand;
using Domain.Repository;
using Domain.Entity;

public class AddMovieHandler : IRequestHandler<AddMovieCommand, Movie>
{

    private readonly IMapper _mapper;
    private readonly IMoviesRepository _repository;

    public AddMovieHandler(IMapper mapper, IMoviesRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        Movie movie = _mapper.Map<Movie>(request);
        return _repository.AddAsync(movie);
    }
}