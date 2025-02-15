using MediatR;

namespace MiniE_Commerce.Application.Features.Queries.Basket.GetBasketItem
{
    public class GetBasketItemQueryRequest : IRequest<List<GetBasketItemQueryResponse>>
    {
    }
}
