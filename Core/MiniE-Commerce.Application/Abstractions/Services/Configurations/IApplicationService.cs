using MiniE_Commerce.Application.DTO.Configurations;

namespace MiniE_Commerce.Application.Abstractions.Services.Configurations
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
