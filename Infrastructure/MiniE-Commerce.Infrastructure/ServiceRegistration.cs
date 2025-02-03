using Microsoft.Extensions.DependencyInjection;
using MiniE_Commerce.Application.Abstractions.Storage;
using MiniE_Commerce.Infrastructure.Enums;
using MiniE_Commerce.Infrastructure.Services.Storage;
using MiniE_Commerce.Infrastructure.Services.Storage.Azure;
using MiniE_Commerce.Infrastructure.Services.Storage.Local;

namespace MiniE_Commerce.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
