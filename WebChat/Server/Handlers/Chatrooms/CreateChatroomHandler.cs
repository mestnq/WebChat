using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Requests.Message;
using WebChat.Shared.Result.Chatroom;
using WebChat.Shared.Result.Message;

namespace WebChat.Server.Handlers.Chatrooms;

public class CreateChatroomHandler : IRequestHandler<CreateChatroomRequest, ChatroomResult>
{
    private readonly IMapper _mapper;
    private readonly ChatroomService _chatroomService;

    public CreateChatroomHandler(ChatroomService chatroomService, IMapper mapper)
    {
        _chatroomService = chatroomService;
        _mapper = mapper;
    }

    public async Task<ChatroomResult> Handle(CreateChatroomRequest request, CancellationToken cancellationToken)
    {
        var chatroom = await _chatroomService.CreateChatroom(_mapper.Map<Data.Entities.Models.Chatroom>(request.Chatroom));
        
        return new ChatroomResult()
        {
            Chatroom = _mapper.Map<ChatroomDto>(chatroom)
        };
    }
}