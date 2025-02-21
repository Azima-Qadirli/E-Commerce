using MiniE_Commerce.Application.DTO.Order;

namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder order);
        Task<ListOrder> GetAllOrdersAsync(int page, int size);
    }
}
