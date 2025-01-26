using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Domain.Entities.Common;

namespace MiniE_Commerce.Persistence.Contexts
{
    public class MiniE_CommerceDbContext : DbContext
    {
        public MiniE_CommerceDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //ChangeTracker: It is a property that allows the changes made on entities or newly added data to be captured. It allows us to capture and obtain the tracked data in update operations.

            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedAt = DateTime.UtcNow,
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
