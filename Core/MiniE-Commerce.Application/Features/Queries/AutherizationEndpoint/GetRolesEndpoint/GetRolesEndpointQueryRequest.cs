using MediatR;

namespace MiniE_Commerce.Application.Features.Queries.AutherizationEndpoint.GetRolesEndpoint
{
    public class GetRolesEndpointQueryRequest : IRequest<GetRolesEndpointQueryResponse>
    {
        public string Code { get; set; }
        public string Menu { get; set; }
    }
}
