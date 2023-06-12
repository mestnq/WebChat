using MediatR;
using WebChat.Shared.Result;

namespace WebChat.Shared.Requests.User;

public record UpdateUserRequest : IRequest<UserResult>
{
    public required long UserId { get; init; }
    public required string nickame { get; init; }
}