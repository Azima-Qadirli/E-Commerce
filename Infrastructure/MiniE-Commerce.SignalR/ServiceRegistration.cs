using Microsoft.Extensions.DependencyInjection;
using MiniE_Commerce.Application.Abstractions.Hubs;
using MiniE_Commerce.SignalR.HubServices;

namespace MiniE_Commerce.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddTransient<IProductHubService, ProductHubService>();
            services.AddTransient<IOrderHubService, OrderHubService>();
            services.AddSignalR();
        }

    }
}
