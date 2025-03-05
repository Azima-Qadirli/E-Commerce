using MediatR;
using MiniE_Commerce.Application.Abstractions.Services;

namespace MiniE_Commerce.Application.Features.Queries.AutherizationEndpoint.GetRolesEndpoint
{
    public class GetRolesEndpointQueryHandler : IRequestHandler<GetRolesEndpointQueryRequest, GetRolesEndpointQueryResponse>
    {
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public GetRolesEndpointQueryHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<GetRolesEndpointQueryResponse> Handle(GetRolesEndpointQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _authorizationEndpointService.GetRolesToEndpointAsync(request.Menu, request.Code);
            return new()
            {
                Roles = data
            };
        }
    }
}
