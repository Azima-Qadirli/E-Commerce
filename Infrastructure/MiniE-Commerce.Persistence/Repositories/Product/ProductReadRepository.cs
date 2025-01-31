using MiniE_Commerce.Application.Repositories;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
