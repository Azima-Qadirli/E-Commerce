using MiniE_Commerce.Application.Abstractions.Services.Authentications;

namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {

    }
}
