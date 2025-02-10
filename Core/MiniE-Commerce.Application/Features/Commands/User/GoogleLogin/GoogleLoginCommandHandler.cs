using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniE_Commerce.Application.Abstractions.Token;
using MiniE_Commerce.Application.DTO;
using MiniE_Commerce.Domain.Entities.Identity;

namespace MiniE_Commerce.Application.Features.Commands.User.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;

        public GoogleLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "1015812911905-dvivd49ktihch509hta6r9f95ri36sfm.apps.googleusercontent.com" }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
            var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);
            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        NameSurname = payload.Name,
                        UserName = payload.Email
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }
            if (result)
                await _userManager.AddLoginAsync(user, info);//here user's data will go to AspNetUserLogins in DB.
            else
                throw new Exception("Invalid external authentication!");

            Token token = _tokenHandler.CreateAccessToken(5);
            return new()
            {
                Token = token
            };


        }
    }
}
