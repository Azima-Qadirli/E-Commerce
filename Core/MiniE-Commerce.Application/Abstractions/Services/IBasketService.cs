using MiniE_Commerce.Application.ViewModels.Baskets;
using MiniE_Commerce.Domain.Entities;

namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemAsync();
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);
        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
    }
}
