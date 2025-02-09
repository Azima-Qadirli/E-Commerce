using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniE_Commerce.Domain.Entities.Identity;

namespace MiniE_Commerce.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                Email = request.Email,
                UserName = request.UserName,
            }, request.Password);

            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User is created successfully!";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}";
            return response;

            //throw new CreateUserFailedException();
        }
    }
}
