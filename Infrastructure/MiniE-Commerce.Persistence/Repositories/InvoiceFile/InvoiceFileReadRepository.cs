using MiniE_Commerce.Application.Repositories.InvoiceFile;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }

}
