﻿using MediatR;
using MiniE_Commerce.Application.Abstractions.Services;

namespace MiniE_Commerce.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.UpdateRole(request.Id, request.Name);
            return new()
            {
                Succeeded = result
            };
        }
    }
}
