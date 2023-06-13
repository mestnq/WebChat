using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Result.Chatroom;
using WebChat.Shared.Result.Message;

namespace WebChat.Server.Handlers.Chatrooms;

public class GetMessagesInChatroomHandler : IRequestHandler<GetMessagesInChatroomRequest, MessagesResult>
{
    private readonly IMapper _mapper;
    private readonly ChatroomService _chatroomService;

    public GetMessagesInChatroomHandler(ChatroomService chatroomService, IMapper mapper)
    {
        _chatroomService = chatroomService;
        _mapper = mapper;
    }

    public async Task<MessagesResult> Handle(GetMessagesInChatroomRequest request, CancellationToken cancellationToken)
    {
        //todo:
        // var messages = await _chatroomService.GetMessagesInChatroom(_mapper.Map<Data.Entities.Models.Chatroom>(request.Chatroom));
        //
        // return new MessagesResult()
        // {
        //     Messages = _mapper.Map<ICollection<MessageDto>>(messages)
        // };
        return new MessagesResult() { Messages = new List<MessageDto>() };
    }
}