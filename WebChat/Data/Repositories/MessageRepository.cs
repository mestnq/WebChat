using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class MessageRepository: Repository<Message>
{
    public MessageRepository(ChatContext dbContext) : base(dbContext) { }
        
    public async ValueTask<Message?> GetMessage(int id) => await GetById(id);
}