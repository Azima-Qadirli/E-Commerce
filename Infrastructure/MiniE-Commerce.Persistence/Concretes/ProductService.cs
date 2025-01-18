using MiniE_Commerce.Application.Abstractions;
using MiniE_Commerce.Domain.Entities;

namespace MiniE_Commerce.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetAllProducts()
            => new()
            {
               new(){Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 100},
               new(){Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 500},
               new(){Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 600},
               new(){Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock = 700}
            };
    }
}
