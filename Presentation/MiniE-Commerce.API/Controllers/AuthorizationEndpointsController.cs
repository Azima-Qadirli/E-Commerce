using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application.Features.Commands.AutherizationEndpoint;
using MiniE_Commerce.Application.Features.Queries.AutherizationEndpoint.GetRolesEndpoint;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("action")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesEndpointQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest request)
        {
            request.Type = typeof(Program);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
