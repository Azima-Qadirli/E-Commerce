using MediatR;
using MiniE_Commerce.Application.Abstractions.Services;

namespace MiniE_Commerce.Application.Features.Queries.Basket.GetBasketItem
{
    public class GetBasketItemQueryHandler : IRequestHandler<GetBasketItemQueryRequest, List<GetBasketItemQueryResponse>>
    {
        readonly IBasketService _basketService;

        public GetBasketItemQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<List<GetBasketItemQueryResponse>> Handle(GetBasketItemQueryRequest request, CancellationToken cancellationToken)
        {
            var basketItems = await _basketService.GetBasketItemAsync();
            return basketItems.Select(ba => new GetBasketItemQueryResponse
            {
                BasketItemId = ba.Id.ToString(),
                Name = ba.Product.Name,
                Price = ba.Product.Price,
                Quantity = ba.Quantity
            }).ToList();
        }
    }
}
