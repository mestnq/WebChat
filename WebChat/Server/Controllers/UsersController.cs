using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result.User;

namespace WebChat.Server.Controllers;


public class UsersController : Hub
{
    private readonly IMediator _mediator;
    private readonly IHubContext<UsersController> _hubContext;

    public UsersController(IMediator mediator, IHubContext<UsersController> hubContext)
    {
        _mediator = mediator;
        _hubContext = hubContext;
    }

    public async Task GetUsers()
    {
        await _hubContext.Clients.All.SendAsync("GetUsers", _mediator.Send(new GetUsersRequest()));
    }

    public async Task GetUser(int id)
    {
        var result = await _mediator.Send(new GetUserRequest()
        {
            UserId = id
        });
        if (result?.User is null)
        {
            await _hubContext.Clients.All.SendAsync("UserNotFound", id);
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("GetUser", result);
        }
    }

    public async Task CreateUser(CreateUserRequest createUserRequest)
    {
        var result = await _mediator.Send(createUserRequest);
        if (result?.User is null)
        {
            await _hubContext.Clients.All.SendAsync("UserConflict");
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("CreateUser", result);
        }
    }

    public async Task ChangeNicknameUser(UpdateUserRequest updateUserRequest)
    {
        var result = await _mediator.Send(updateUserRequest);
        if (result?.User is null)
        {
            await _hubContext.Clients.All.SendAsync("UserNotFound", updateUserRequest.Nickname);
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("UpdateUser", result);
        }
    }

    public async Task DeleteUser(int id)
    {
        var result = await _mediator.Send(new DeleteUserRequest()
        {
            UserId = id
        });
        if (!result)
        {
            await _hubContext.Clients.All.SendAsync("UserNotFound", id);
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("DeleteUser", id);
        }
    }
}