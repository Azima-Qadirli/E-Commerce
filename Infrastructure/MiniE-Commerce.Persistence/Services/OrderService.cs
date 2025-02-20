using MiniE_Commerce.Application.Abstractions.Services;
using MiniE_Commerce.Application.DTO.Order;
using MiniE_Commerce.Application.Repositories;

namespace MiniE_Commerce.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrder order)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address = order.Address,
                Id = Guid.Parse(order.BasketId),
                Description = order.Description
            });
            await _orderWriteRepository.SaveAsync();
        }
    }
}
