namespace Movies.API.Infraestructure.Controller;

using Application.Movie.Query;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Movie.Commmand;
using Application.Movie.Dto;
using Domain.Config;
using Domain.Entity;
using Base;
using Router;

[Route(RoutesPath.ApiRoute)]
[ApiController]
public class MoviesController : ApiControllerBase
{
    private readonly IMapper _mapper;
    
    public MoviesController(IMediator mediator, IMapper mapper) : base(mediator)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Save new Movie
    /// </summary>
    /// <param name="addMovieDto"></param>
    /// <returns></returns>
    /// <response code="201">Created</response>     
    /// <response code="400">BadRequest</response> 
    /// <response code="500">InternalServerError</response> 
    [ProducesResponseType(typeof(Movie), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost(RoutesPath.Movies.Add)]
    public async Task<IActionResult> Add(AddMovieDto addMovieDto)
    {
        AddMovieCommand addMovieCommand = _mapper.Map<AddMovieCommand>(addMovieDto);
        Movie movie = await CommandAsync(addMovieCommand);
        
        string urlBase = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        string locationUri = $"{urlBase}/{RoutesPath.Movies.Get.Replace("{id}", movie._id)}";
        
        return Created(locationUri, movie);
    }


    /// <summary>
    /// Update Movie
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateMovieDto"></param>
    /// <returns></returns>
    /// <response code="200">Ok</response>     
    /// <response code="400">BadRequest</response> 
    /// <response code="500">InternalServerError</response> 
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    [HttpPut(RoutesPath.Movies.Update)]
    public async Task<IActionResult> Update(string id, UpdateMovieDto updateMovieDto) 
    {
        Movie movie = await QueryAsync(new GetMovieQuery() { id = id });
        
        UpdateMovieCommand updateMovieCommand = _mapper.Map<UpdateMovieCommand>(updateMovieDto);
        updateMovieCommand.movie = movie;
        movie = await CommandAsync(updateMovieCommand);

        return Ok(movie);
    }

    /// <summary>
    /// Get Movie
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Created</response>     
    /// <response code="400">BadRequest</response> 
    /// <response code="500">InternalServerError</response> 
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet(RoutesPath.Movies.Get)]
    public async Task<IActionResult> Get(string id)
    {
        Movie movie = await QueryAsync(new GetMovieQuery() { id = id });
        return Ok(movie);
    }

    /// <summary>
    /// Get All Movies
    /// </summary>
    /// <returns></returns>
    /// <response code="200">OK</response>     
    /// <response code="500">InternalServerError</response> 
    [ProducesResponseType(typeof(List<Movie>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet(RoutesPath.Movies.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        List<Movie> movies = await QueryAsync(new GetAllMoviesQuery());
        return Ok(movies);
    }
}