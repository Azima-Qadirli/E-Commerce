using Microsoft.AspNetCore.SignalR;
using MiniE_Commerce.Application.Abstractions.Hubs;

namespace MiniE_Commerce.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext _context;

        public ProductHubService(IHubContext context)
        {
            _context = context;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _context.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage, message);
        }
    }
}
