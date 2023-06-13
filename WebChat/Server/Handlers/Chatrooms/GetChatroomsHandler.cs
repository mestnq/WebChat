using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Server.Handlers.Chatrooms;

public class GetChatroomsHandler : IRequestHandler<GetChatroomsRequest, GetChatroomsResult>
{
    private readonly IMapper _mapper;
    private readonly ChatroomService _chatroomService;

    public GetChatroomsHandler(ChatroomService chatroomService, IMapper mapper)
    {
        _chatroomService = chatroomService;
        _mapper = mapper;
    }

    public async Task<GetChatroomsResult> Handle(GetChatroomsRequest request, CancellationToken cancellationToken)
    {
        //todo:
        var chatroom = await _chatroomService.GetAllChatroom(request.UserId);
        
        return new GetChatroomsResult()
        {
            Chatrooms= _mapper.Map<ChatroomDto>(chatroom)
        };
        //
        // var users = await _userService.GetAllUser();
        //
        // return new GetUsersResult()
        // {
        //     Users = _mapper.Map<ICollection<UserDto>>(users)
        // };
    }
}