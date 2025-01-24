using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Application.Repositories;
using MiniE_Commerce.Domain.Entities.Common;
using MiniE_Commerce.Persistence.Contexts;
using System.Linq.Expressions;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly MiniE_CommerceDbContext _context;

        public ReadRepository(MiniE_CommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        => await Table.FindAsync(Guid.Parse(id));
    }
}
