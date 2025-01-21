using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<MiniE_CommerceDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
