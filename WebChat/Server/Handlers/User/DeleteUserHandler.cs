using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result;

namespace WebChat.Server.Handlers.User;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, bool>
{
    private readonly UserService _userService;

    public DeleteUserHandler(UserService userService)
    {
        _userService = userService;
    }

    public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.DeleteUser(request.UserId);
    }
}