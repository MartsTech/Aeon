using BuildingBlocks.Core;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Web;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController: ControllerBase
{
    private IMediator _mediator = null!;
    
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>()!;
    
    private IPublishEndpoint _publishEndpoint =  null!;
    
    protected IPublishEndpoint PublishEndpoint => _publishEndpoint ??= HttpContext.RequestServices
        .GetService<IPublishEndpoint>()!;
    
    protected ActionResult HandleResult<T>(Result<T>? result)
    {
        if (result == null)
        {
            return NotFound();
        }
        if (result.IsSuccess && result.Value != null)
        {
            return Ok(result.Value);
        }
        if (result.IsSuccess && result.Value == null)
        {
            return NotFound();
        }
        return BadRequest(result.Error);
    }
    
    protected void HandlePublish<T>(T @event) where T : class
    {
        PublishEndpoint.Publish(@event);
    }
}