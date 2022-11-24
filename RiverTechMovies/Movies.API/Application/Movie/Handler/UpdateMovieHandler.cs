using AutoMapper;

namespace Movies.API.Application.Movie.Handler;

using Domain.Repository;
using MediatR;
using Domain.Entity;
using Commmand;


public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, Movie>
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;

    public UpdateMovieHandler(IMovieRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        Movie movie = build(request);
        return _repository.Update(movie);
    }

    private Movie build(UpdateMovieCommand request)
    {
        return new Movie()
        {
            _id = request.movie._id,
            Id = (request.Id == null) ? request.Id : request.movie.Id,
            Description =(!String.IsNullOrEmpty(request.Description)) ? request.Description : request.movie.Description,
            Img = (!String.IsNullOrEmpty(request.Img)) ? request.Img : request.movie.Img,
            Key = (!String.IsNullOrEmpty(request.Key)) ? request.Key : request.movie.Key,
            Length = (!String.IsNullOrEmpty(request.Length)) ? request.Length : request.movie.Length,
            Name = (!String.IsNullOrEmpty(request.Name)) ? request.Name : request.movie.Name,
            Rate = (!String.IsNullOrEmpty(request.Rate)) ? request.Rate : request.movie.Rate,
            Genres = (request.Geners.Count > 0) ? _mapper.Map<List<String>>(request.Geners): request.movie.Genres
        };
    }
}