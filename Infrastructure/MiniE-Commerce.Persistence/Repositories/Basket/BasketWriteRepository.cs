using MiniE_Commerce.Application.Repositories.Baskets;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
