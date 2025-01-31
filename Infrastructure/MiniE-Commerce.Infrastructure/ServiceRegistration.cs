using Microsoft.Extensions.DependencyInjection;
using MiniE_Commerce.Application.Services;
using MiniE_Commerce.Infrastructure.Services;

namespace MiniE_Commerce.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
        }
    }
}
