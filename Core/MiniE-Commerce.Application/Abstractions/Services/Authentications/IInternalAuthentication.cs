namespace MiniE_Commerce.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<DTO.Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime);
    }
}
