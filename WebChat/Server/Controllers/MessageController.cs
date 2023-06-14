using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebChat.Shared.Requests.Message;

namespace WebChat.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // POST: api/messages/add
    [HttpPost("messages/add")]
    public IActionResult CreateMessage([FromBody] CreateMessageRequest createUserRequest)
    {
        var e = _mediator.Send(createUserRequest);
        return e?.Result?.Message is null ? Conflict() : Ok(e.Result);
    }
}