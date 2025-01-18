using MiniE_Commerce.Domain.Entities;

namespace MiniE_Commerce.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
    }
}
