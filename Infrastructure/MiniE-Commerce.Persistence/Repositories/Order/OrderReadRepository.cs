using MiniE_Commerce.Application.Repositories.Order;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
