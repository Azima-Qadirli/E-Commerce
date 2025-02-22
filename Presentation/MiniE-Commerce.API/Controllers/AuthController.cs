using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application.Features.Commands.User.FacebookLogin;
using MiniE_Commerce.Application.Features.Commands.User.GoogleLogin;
using MiniE_Commerce.Application.Features.Commands.User.LoginUser;
using MiniE_Commerce.Application.Features.Commands.User.PasswordReset;
using MiniE_Commerce.Application.Features.Commands.User.RefreshTokenLogin;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest request)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("facebook-login")]
        public async Task<IActionResult> FacebookLogin(FacebookLoginCommandRequest request)
        {
            FacebookLoginCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
