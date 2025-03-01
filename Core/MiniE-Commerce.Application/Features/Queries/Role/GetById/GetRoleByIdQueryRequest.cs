using MediatR;

namespace MiniE_Commerce.Application.Features.Queries.Role.GetById
{
    public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
