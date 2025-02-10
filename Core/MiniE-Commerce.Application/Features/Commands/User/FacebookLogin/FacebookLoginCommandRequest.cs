using MediatR;

namespace MiniE_Commerce.Application.Features.Commands.User.FacebookLogin
{
    public class FacebookLoginCommandRequest : IRequest<FacebookLoginCommandResponse>
    {
        public string AuthToken { get; set; }
    }
}
