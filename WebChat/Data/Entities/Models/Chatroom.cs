namespace WebChat.Data.Entities.Models;

public class Chatroom : BaseModel
{
    public string Name { get; set; }
    public ICollection<long> MessagesId { get; set; } = new List<long>();
    public ICollection<long> UsersId { get; set; } = new List<long>();
}