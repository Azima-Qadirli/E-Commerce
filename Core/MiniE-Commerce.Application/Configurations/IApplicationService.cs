using MiniE_Commerce.Application.DTO.Configurations;

namespace MiniE_Commerce.Application.Configurations
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
