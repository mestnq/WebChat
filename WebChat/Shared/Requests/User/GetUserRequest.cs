using MediatR;
using WebChat.Shared.Result;

namespace WebChat.Shared.Requests.User;

public record GetUserRequest : IRequest<UserResult>
{
    public required long UserId { get; init; }
}