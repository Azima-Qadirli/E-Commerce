using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Domain.Entities.Common;

namespace MiniE_Commerce.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
