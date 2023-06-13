using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebChat.Shared.Requests;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result;
using WebChat.Shared.Result.User;

namespace WebChat.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/users
    [HttpGet("users")]
    public Task<GetUsersResult> GetUsers()
    {
        return _mediator.Send(new GetUsersRequest());
    }

    // GET: api/users/current
    [HttpGet("users/current")]
    public IActionResult GetUser([FromQuery] GetUserRequest getUserRequest)
    {
        var e = _mediator.Send(getUserRequest);
        return e?.Result?.User is null ? NotFound() : Ok(e.Result);
    }
    
    // POST: api/users/add
    [HttpPost("users/add")]
    public IActionResult CreateUser([FromQuery] CreateUserRequest createUserRequest)
    {
        var e = _mediator.Send(createUserRequest);
        return e?.Result?.User is null ? Conflict() : Ok(e.Result);
    }
    
    // POST: api/users/current/change-nickname
    [HttpPost("users/current/change-nickname")]
    public IActionResult ChangeNicknameUser([FromQuery] UpdateUserRequest updateUserRequest)
    {
        var e = _mediator.Send(updateUserRequest);
        return e?.Result?.User is null ? NotFound() : Ok(e.Result); //TODO: подумать про "?", а то расставлять их в час ночи не айс
    }
    
    // DELETE: api/users/current
    [HttpDelete("users/current")]
    public IActionResult DeleteUser([FromQuery] DeleteUserRequest deleteUserRequest)
    {
        var e = _mediator.Send(deleteUserRequest);
        return !e.Result ? StatusCode(503) : Ok(e.Result);
    }
}