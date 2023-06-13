using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebChat.Shared.Requests;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Requests.Message;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatroomController : ControllerBase
{
    // Спроектировать rest api с crud операциями для пользователей и чатов
    // листинг чатов, сообщений одного чата;
    // мягкое удаление чатов - вместо удаления из БД запись отмечается как удалённая;
    // обновление названия чата)
    
    private readonly IMediator _mediator;

    public ChatroomController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // POST: api/chatrooms/add
    [HttpPost("chatrooms/add")]
    public IActionResult CreateChatroom([FromQuery] CreateChatroomRequest createChatroomRequest)
    {
        var e = _mediator.Send(createChatroomRequest);
        return e?.Result?.Chatroom is null ? Conflict() : Ok(e.Result);
    }
    
    // GET: api/chatrooms/current/messages
    [HttpGet("chatrooms/current/messages")]
    public IActionResult GetMessagesInChatroom([FromQuery] GetMessagesInChatroomRequest getMessagesInChatroomRequest)
    {
        var e = _mediator.Send(getMessagesInChatroomRequest);
        return e?.Result?.Messages is null ? NotFound() : Ok(e.Result?.Messages);
    }
    
    // GET: api/chatrooms/current/user
    [HttpGet("chatrooms/current/user")]
    public Task<GetChatroomsResult> GetChatrooms([FromQuery] GetChatroomsRequest getChatroomsRequest)
    {
        return _mediator.Send(getChatroomsRequest);
    }
    
    // // POST: api/users/add
    // [HttpPost("users/add")]
    // public IActionResult CreateUser([FromQuery] CreateUserRequest createUserRequest)
    // {
    //     var e = _mediator.Send(createUserRequest);
    //     return e?.Result?.User is null ? Conflict() : Ok(e.Result);
    // }
    //
    // // POST: api/users/current/change-nickname
    // [HttpPost("users/current/change-nickname")]
    // public IActionResult ChangeNicknameUser([FromQuery] UpdateUserRequest updateUserRequest)
    // {
    //     var e = _mediator.Send(updateUserRequest);
    //     return e?.Result?.User is null ? NotFound() : Ok(e.Result); //TODO: подумать про "?", а то расставлять их в час ночи не айс
    // }
    //
    // // DELETE: api/users/current
    // [HttpDelete("users/current")]
    // public IActionResult DeleteUser([FromQuery] DeleteUserRequest deleteUserRequest)
    // {
    //     var e = _mediator.Send(deleteUserRequest);
    //     return !e.Result ? StatusCode(503) : Ok(e.Result);
    // }
}