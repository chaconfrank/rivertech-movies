using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Infraestructure.Controller.Base;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class ApiControllerBase : ControllerBase
{
    private readonly IMediator mediator;

    public ApiControllerBase(IMediator mediator)
    {
        this.mediator = mediator;
    }

    protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        => await mediator.Send(query);

    protected ActionResult<T> Single<T>(T data)
    {
        if (data == null) return NotFound();
        return Ok(data);
    }

    protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        => await mediator.Send(command);
}