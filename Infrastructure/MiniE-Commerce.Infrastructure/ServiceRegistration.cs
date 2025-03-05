using Microsoft.Extensions.DependencyInjection;
using MiniE_Commerce.Application.Abstractions.Services;
using MiniE_Commerce.Application.Abstractions.Services.Configurations;
using MiniE_Commerce.Application.Abstractions.Storage;
using MiniE_Commerce.Application.Abstractions.Token;
using MiniE_Commerce.Infrastructure.Enums;
using MiniE_Commerce.Infrastructure.Services;
using MiniE_Commerce.Infrastructure.Services.Configurations;
using MiniE_Commerce.Infrastructure.Services.Storage;
using MiniE_Commerce.Infrastructure.Services.Storage.Azure;
using MiniE_Commerce.Infrastructure.Services.Storage.Local;
using MiniE_Commerce.Infrastructure.Services.Token;

namespace MiniE_Commerce.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
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
