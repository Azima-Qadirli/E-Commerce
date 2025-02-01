using MiniE_Commerce.Application.Repositories.File;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class FileReadRepository : ReadRepository<MiniE_Commerce.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
