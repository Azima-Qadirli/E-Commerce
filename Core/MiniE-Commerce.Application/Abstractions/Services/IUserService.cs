using MiniE_Commerce.Application.DTO.User;

namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
    }
}
