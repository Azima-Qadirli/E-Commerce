using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MiniE_CommerceDbContext>
    {
        public MiniE_CommerceDbContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<MiniE_CommerceDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(optionsBuilder.Options);
        }
    }
}
