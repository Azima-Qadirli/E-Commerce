using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MiniE_Commerce.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
