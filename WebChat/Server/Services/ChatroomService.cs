using WebChat.Data.Entities.Dtos;
using WebChat.Data.Entities.Models;
using WebChat.Data.Repositories;

namespace WebChat.Server.Services;

public class ChatroomService : IService
{
    private readonly ChatroomRepository _chatroomRepository;

    public ChatroomService(ChatroomRepository chatroomRepository)
    {
        _chatroomRepository = chatroomRepository;
    }
    
    public async Task<Chatroom?> CreateChatroom(Chatroom chatroom)
    {
        var count= chatroom.UsersId.Count(x => _chatroomRepository.ContainsEntities(x));

        return count == 0 && _chatroomRepository.GetChatroom(chatroom.Id).Result is null ? await _chatroomRepository.AddChatroom(chatroom) : null;
    }
    
    public async Task<Chatroom?> GetMessagesInChatroom(long chatroomId)
    {
        //todo:
        return null;
    }
    
    public async Task<IReadOnlyCollection<Chatroom>> GetAllChatroom(long userId)
    {
        return await _chatroomRepository.GetChatrooms(userId);
    }
}