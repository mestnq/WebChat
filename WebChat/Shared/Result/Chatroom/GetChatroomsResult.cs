namespace WebChat.Shared.Result.Chatroom;

public record GetChatroomsResult
{
    public required ICollection<Data.Entities.Models.Chatroom> Chatrooms { get; init; }
}