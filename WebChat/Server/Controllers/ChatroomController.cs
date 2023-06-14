using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebChat.Shared.Requests.Chatroom;

namespace WebChat.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatroomController : ControllerBase
{
    // обновление названия чата)
    
    private readonly IMediator _mediator;

    public ChatroomController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // POST: api/chatrooms/add
    [HttpPost("chatrooms/add")]
    public IActionResult CreateChatroom([FromBody] CreateChatroomRequest createChatroomRequest)
    {
        var e = _mediator.Send(createChatroomRequest);
        return e?.Result?.Chatroom is null ? Conflict() : Ok(e.Result);
    }
    
    // GET: api/chatrooms/current/messages
    [HttpGet("chatrooms/current/messages")]
    public IActionResult GetMessagesInChatroom([FromQuery] GetMessagesInChatroomRequest getMessagesInChatroomRequest)
    {
        var e = _mediator.Send(getMessagesInChatroomRequest);
        return e?.Result?.Messages.Count == 0 ? NotFound() : Ok(e?.Result?.Messages);
    }
    
    // GET: api/chatrooms/current/user
    [HttpGet("chatrooms/current/user")]
    public IActionResult GetUserChatrooms([FromQuery] GetUserChatroomsRequest getUserChatroomsRequest)
    {
        var e = _mediator.Send(getUserChatroomsRequest);
        return e?.Result.Chatrooms.Count == 0 ? NotFound() : Ok(e?.Result);    
    }
    
    // POST: api/chatrooms/current/change-name
    [HttpPost("chatrooms/current/change-name")]
    public IActionResult ChangeNicknameUser([FromBody] UpdateChatroomRequest updateUserRequest)
    {
        var e = _mediator.Send(updateUserRequest);
        return e.Result?.Chatroom is null ? NotFound() : Ok(e.Result);
    }
    
    // DELETE: api/chatrooms/current
    [HttpDelete("chatrooms/current")]
    public IActionResult DeleteUser([FromQuery] DeleteChatroomRequest deleteUserRequest)
    {
        var e = _mediator.Send(deleteUserRequest);
        return !e.Result ? StatusCode(503) : Ok(e.Result);
    }
}