using MediatR;

namespace MiniE_Commerce.Application.Features.Queries.User.GetAllUsers
{
    public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
