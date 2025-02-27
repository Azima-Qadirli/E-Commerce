using MediatR;

namespace MiniE_Commerce.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}
