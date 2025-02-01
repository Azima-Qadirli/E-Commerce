using MiniE_Commerce.Application.Repositories.InvoiceFile;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
