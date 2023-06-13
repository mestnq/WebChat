using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Shared.Requests.Chatroom;

public record CreateChatroomRequest : IRequest<ChatroomResult>
{
    public required ChatroomDto Chatroom { get; set; }
}