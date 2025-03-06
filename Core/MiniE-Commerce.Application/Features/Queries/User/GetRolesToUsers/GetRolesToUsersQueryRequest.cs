using MediatR;

namespace MiniE_Commerce.Application.Features.Queries.User.GetRolesToUsers
{
    public class GetRolesToUsersQueryRequest : IRequest<GetRolesToUsersQueryResponse>
    {
        public string UserId { get; set; }
    }
}
