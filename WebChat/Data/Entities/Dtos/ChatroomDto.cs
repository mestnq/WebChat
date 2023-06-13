namespace WebChat.Data.Entities.Dtos;

public class ChatroomDto : BaseDto
{
    public string Name { get; set; }
    public ICollection<long>? MessagesId { get; set; } = new List<long>();
    public ICollection<long>? UsersId { get; set; } = new List<long>();
}