using MiniE_Commerce.Application.Repositories.File;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<MiniE_Commerce.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
