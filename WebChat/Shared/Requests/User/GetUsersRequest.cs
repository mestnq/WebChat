using MediatR;
using WebChat.Shared.Result;

namespace WebChat.Shared.Requests.User;

public record GetUsersRequest : IRequest<GetUsersResult>
{
    
}