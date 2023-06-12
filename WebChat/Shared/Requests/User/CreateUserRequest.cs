using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Shared.Result;

namespace WebChat.Shared.Requests.User;

public record CreateUserRequest : IRequest<UserResult>
{
    public required UserDto User { get; set; }
}