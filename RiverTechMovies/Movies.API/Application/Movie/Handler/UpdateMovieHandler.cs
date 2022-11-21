namespace Movies.API.Application.Movie.Handler;

using Domain.Repository;
using MediatR;
using Domain.Entity;
using Commmand;


public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, Movie>
{
    private readonly IMoviesRepository _repository;

    public UpdateMovieHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }

    public Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        Movie movie = build(request);
        return _repository.UpdateAsync(movie);
    }

    private Movie build(UpdateMovieCommand request)
    {
        return new Movie()
        {
            Id = request.movie.Id,
            Description =
                (!String.IsNullOrEmpty(request.Description)) ? request.Description : request.movie.Description,
            Img = (!String.IsNullOrEmpty(request.Img)) ? request.Img : request.movie.Img,
            Key = (!String.IsNullOrEmpty(request.Key)) ? request.Key : request.movie.Key,
            Length = (!String.IsNullOrEmpty(request.Length)) ? request.Length : request.movie.Length,
            Name = (!String.IsNullOrEmpty(request.Name)) ? request.Name : request.movie.Name,
            Rate = (!String.IsNullOrEmpty(request.Rate)) ? request.Rate : request.movie.Rate,
        };
    }
}