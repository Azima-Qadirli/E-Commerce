using Microsoft.AspNetCore.Builder;
using MiniE_Commerce.SignalR.Hubs;

namespace MiniE_Commerce.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductHub>("/products-hub");
            webApplication.MapHub<OrderHub>("/orders-hub");
        }
    }
}
