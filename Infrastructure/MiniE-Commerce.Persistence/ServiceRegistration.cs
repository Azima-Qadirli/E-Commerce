using Microsoft.Extensions.DependencyInjection;
using MiniE_Commerce.Application.Abstractions;
using MiniE_Commerce.Persistence.Concretes;

namespace MiniE_Commerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
