using WebChat.Data.Entities.Dtos;
using WebChat.Data.Entities.Models;

namespace WebChat.Shared.Result;

public record GetUsersResult
{
    public required ICollection<UserDto> Users { get; set; }
}