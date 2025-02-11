using MiniE_Commerce.Application.DTO.User;
using MiniE_Commerce.Domain.Entities.Identity;

namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
