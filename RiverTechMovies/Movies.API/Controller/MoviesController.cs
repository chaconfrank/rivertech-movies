using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Controller.Base;
using Movies.API.Router;
using Movies.Application.Movie.Commmand;
using Movies.Application.Movie.Dto;
using Movies.Domain.Config;

namespace Movies.API.Controller;

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
    /// <param name="AddMovieDto"></param>
    /// <returns></returns>
    /// <response code="201">Created</response>     
    /// <response code="400">BadRequest</response> 
    /// <response code="500">InternalServerError</response> 
    [ProducesResponseType(typeof(Domain.Entity.Movies), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost("/test")]
    public async Task<IActionResult> Add(AddMovieDto addMovieDto)
    {
        string urlBase = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        AddMovieCommand addMovieCommand = _mapper.Map<AddMovieCommand>(addMovieDto);
        return Created(urlBase, await CommandAsync(addMovieCommand));
    }
}