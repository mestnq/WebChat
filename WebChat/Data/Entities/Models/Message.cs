namespace WebChat.Data.Entities.Models;

public class Message : BaseModel //TODO: added required, change to init-set
{
    public string MessageText { get; set; }
    public long UserId { get; set; }
    public long ChatroomId { get; set; }
}