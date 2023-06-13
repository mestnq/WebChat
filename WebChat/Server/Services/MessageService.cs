using WebChat.Data.Entities.Models;
using WebChat.Data.Repositories;

namespace WebChat.Server.Services;

public class MessageService : IService
{
    private readonly MessageRepository _messageRepository;

    public MessageService(MessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    
    public async Task<Message?> CreateMessage(Message message)
    {
        var foundEntities = _messageRepository.ContainsEntities(message.ChatroomId, message.UserId);
        
        return !foundEntities && _messageRepository.GetMessage(message.Id).Result is null ? await _messageRepository.AddMessage(message) : null;
    }
}