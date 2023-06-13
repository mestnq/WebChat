using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Shared.Result.Message;

namespace WebChat.Shared.Requests.Message;

public record CreateMessageRequest : IRequest<MessageResult>
{
    public required MessageDto Message { get; set; }
}