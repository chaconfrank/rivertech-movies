using AutoMapper;
using MediatR;
using Movies.Application.Movie.Commmand;
using Movies.Domain.Repository;

namespace Movies.Application.Movie.Handler;

public class AddMovieHandler : IRequestHandler<AddMovieCommand, Domain.Entity.Movies>
{

    private readonly IMapper _mapper;
    private readonly IMoviesRepository _repository;

    public AddMovieHandler(IMapper mapper, IMoviesRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public Task<Domain.Entity.Movies> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        Domain.Entity.Movies movie = _mapper.Map<Domain.Entity.Movies>(request);
        return _repository.AddAsync(movie);
    }
}