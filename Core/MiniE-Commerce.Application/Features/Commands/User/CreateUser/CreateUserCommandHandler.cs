using MediatR;
using MiniE_Commerce.Application.Abstractions.Services;
using MiniE_Commerce.Application.DTO.User;

namespace MiniE_Commerce.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                UserName = request.UserName,
                PasswordConfirm = request.PasswordConfirm
            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };

            //throw new CreateUserFailedException();
        }
    }
}
