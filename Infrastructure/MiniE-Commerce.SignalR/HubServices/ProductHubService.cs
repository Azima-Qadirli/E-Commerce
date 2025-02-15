using Microsoft.AspNetCore.SignalR;
using MiniE_Commerce.Application.Abstractions.Hubs;
using MiniE_Commerce.SignalR.Hubs;

namespace MiniE_Commerce.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext<ProductHub> _context;

        public ProductHubService(IHubContext<ProductHub> context)
        {
            _context = context;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _context.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage, message);
        }
    }
}
