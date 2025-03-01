using MediatR;

namespace MiniE_Commerce.Application.Features.Queries.Role.GetAll
{
    public class GetAllRoleQueryRequest : IRequest<GetAllRoleQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
