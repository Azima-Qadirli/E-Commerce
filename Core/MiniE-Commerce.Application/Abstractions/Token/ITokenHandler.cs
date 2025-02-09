namespace MiniE_Commerce.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTO.Token CreateAccessToken(int minute);
    }
}
