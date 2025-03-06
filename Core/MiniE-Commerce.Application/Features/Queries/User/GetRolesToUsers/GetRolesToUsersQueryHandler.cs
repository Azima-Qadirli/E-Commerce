using MediatR;
using MiniE_Commerce.Application.Abstractions.Services;

namespace MiniE_Commerce.Application.Features.Queries.User.GetRolesToUsers
{
    public class GetRolesToUsersQueryHandler : IRequestHandler<GetRolesToUsersQueryRequest, GetRolesToUsersQueryResponse>
    {
        readonly IUserService _userService;

        public GetRolesToUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetRolesToUsersQueryResponse> Handle(GetRolesToUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var userRoles = await _userService.GetRolesToUsersAsync(request.UserId);
            return new()
            {
                UserRoles = userRoles
            };
        }
    }
}
