using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application.CustomAttributes;
using MiniE_Commerce.Application.Enums;
using MiniE_Commerce.Application.Features.Commands.Role.CreateRole;
using MiniE_Commerce.Application.Features.Commands.Role.DeleteRole;
using MiniE_Commerce.Application.Features.Commands.Role.UpdateRole;
using MiniE_Commerce.Application.Features.Queries.Role.GetAll;
using MiniE_Commerce.Application.Features.Queries.Role.GetById;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get all roles", Menu = "Roles")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetAllRoleQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get role by id", Menu = "Roles")]
        public async Task<IActionResult> GetRoleById([FromRoute] GetRoleByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create role", Menu = "Roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update role", Menu = "Roles")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete role", Menu = "Roles")]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
