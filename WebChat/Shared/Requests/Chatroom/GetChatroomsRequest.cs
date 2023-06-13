using MediatR;
using WebChat.Shared.Result;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Shared.Requests.Chatroom;

public record GetChatroomsRequest : IRequest<GetChatroomsResult>
{
    public required long UserId { get; init; }
}