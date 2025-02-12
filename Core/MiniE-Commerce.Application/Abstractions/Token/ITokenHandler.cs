using MiniE_Commerce.Domain.Entities.Identity;

namespace MiniE_Commerce.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTO.Token CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
