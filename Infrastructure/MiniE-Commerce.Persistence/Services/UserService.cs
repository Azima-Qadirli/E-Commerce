using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Application.Abstractions.Services;
using MiniE_Commerce.Application.DTO.User;
using MiniE_Commerce.Application.Exceptions;
using MiniE_Commerce.Application.Helpers;
using MiniE_Commerce.Application.Repositories;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Domain.Entities.Identity;

namespace MiniE_Commerce.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IEndpointReadRepository _endpointReadRepository;

        public UserService(UserManager<AppUser> userManager, IEndpointReadRepository endpointReadRepository)
        {
            _userManager = userManager;
            _endpointReadRepository = endpointReadRepository;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = model.NameSurname,
                Email = model.Email,
                UserName = model.UserName,
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User is created successfully!";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}";
            return response;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }
        }

        public async Task<List<ListUser>> GetAllUserAsync(int page, int size)
        {
            var users = await _userManager.Users
                .Skip(page * size)
                .Take(size)
                .ToListAsync();
            return users.Select(user => new ListUser
            {
                Id = user.Id,
                Email = user.Email,
                NameSurname = user.NameSurname,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName
            }).ToList();
        }

        public async Task AssingRoleToUserAsync(string userId, string[] roles)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                await _userManager.AddToRolesAsync(user, roles);
            }
        }

        public async Task<string[]> GetRolesToUsersAsync(string userIdOrName)
        {
            AppUser user = await _userManager.FindByIdAsync(userIdOrName);
            if (user == null)
                await _userManager.FindByNameAsync(userIdOrName);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            var userRoles = await GetRolesToUsersAsync(name);
            if (!userRoles.Any())
                return false;
            Endpoint? endpoint = await _endpointReadRepository.Table
                           .Include(e => e.Roles)
                           .FirstOrDefaultAsync(e => e.Code == code);
            if (endpoint == null)
                return false;

            var hasRole = false;
            var endpointRoles = endpoint.Roles.Select(r => r.Name);

            //foreach(var userRole in userRoles)
            //{
            //    if (!hasRole)
            //    {
            //        foreach(var endpointRole in endpointRoles)
            //            if (userRole == endpointRole)
            //            {
            //                hasRole = true;
            //                break;
            //            }
            //    }
            //    else
            //        break;

            //}
            //return hasRole;

            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                    if (userRole == endpointRole)
                        return true;
            }
            return false;
        }

        public int TotalUsersCount => _userManager.Users.Count();
    }
}
