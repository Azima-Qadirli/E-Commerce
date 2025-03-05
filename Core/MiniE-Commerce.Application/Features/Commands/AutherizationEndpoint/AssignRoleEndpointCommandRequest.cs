using MediatR;

namespace MiniE_Commerce.Application.Features.Commands.AutherizationEndpoint
{
    public class AssignRoleEndpointCommandRequest : IRequest<AssignRoleEndpointCommandResponse>
    {
        public string Code { get; set; }
        public string[] Roles { get; set; }
        public string Menu { get; set; }
        public Type? Type { get; set; }
    }
}
