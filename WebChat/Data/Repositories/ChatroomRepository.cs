using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class ChatroomRepository: Repository<Chatroom>
{
    public ChatroomRepository(ChatContext dbContext) : base(dbContext) { }
        
    public async ValueTask<Chatroom?> GetChatroom(int id) => await GetById(id);
}