using Microsoft.EntityFrameworkCore;
using WebChat.Data.Entities.Dtos;
using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class ChatroomRepository: Repository<Chatroom>
{
    public ChatroomRepository(ChatContext dbContext) : base(dbContext) { }
        
    public async ValueTask<Chatroom?> GetChatroom(long id) => await GetById(id);

    //todo:
    // public async ValueTask<Chatroom?> GetMessagesInChatroom(long id)
    // {
    //     var messagesId = GetChatroom(id).Result?.MessagesId;
    //     return await messagesId.Select(x => get)
    // }
    public async ValueTask<Chatroom?> AddChatroom(Chatroom chatroom) => await Add(chatroom);
    
    public async ValueTask<IReadOnlyCollection<Chatroom>> GetChatrooms(long userId)
    {
        //todo: каждый чат содержит юзера. Нужно достать из чатов нашего юзера, и из этого всего получить список.
        // foreach (var chatroom in GetAll())
        // {
        //     var enumerable = chatroom.UsersId.Where(id => userId == id);
        // }
        //
        // return await GetAll().ElementType;
        
        // return await GetAll().Where(i => i.UsersId.)
        //     //.Include()
        //     .ToListAsync(); 
    }
}