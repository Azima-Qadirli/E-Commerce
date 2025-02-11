namespace MiniE_Commerce.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<DTO.Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
        Task<DTO.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
