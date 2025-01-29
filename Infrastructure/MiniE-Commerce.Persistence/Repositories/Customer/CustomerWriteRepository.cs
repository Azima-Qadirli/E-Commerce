using MiniE_Commerce.Application.Repositories.Customer;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
