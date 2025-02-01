using MiniE_Commerce.Application.Repositories.ProductImageFile;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class ProductImageFileWriteRepository : WriteRepository<MiniE_Commerce.Domain.Entities.ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
