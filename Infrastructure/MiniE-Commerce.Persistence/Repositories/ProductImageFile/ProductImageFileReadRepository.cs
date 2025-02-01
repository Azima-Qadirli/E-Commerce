using MiniE_Commerce.Application.Repositories.ProductImageFile;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class ProductImageFileReadRepository : ReadRepository<MiniE_Commerce.Domain.Entities.ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
