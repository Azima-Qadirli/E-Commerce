namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IRoleService
    {
        IDictionary<string, string> GetAllRoles();
        Task<(string id, string name)> GetRoleById(string id);
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string id);
        Task<bool> UpdateRole(string id, string name);
    }
}
