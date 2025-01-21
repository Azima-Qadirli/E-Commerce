using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Domain.Entities;

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

    }
}
