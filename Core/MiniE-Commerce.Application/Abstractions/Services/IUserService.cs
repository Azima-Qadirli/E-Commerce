﻿using MiniE_Commerce.Application.DTO.User;
using MiniE_Commerce.Domain.Entities.Identity;

namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
        Task<List<ListUser>> GetAllUserAsync(int page, int size);
        int TotalUsersCount { get; }
        Task AssingRoleToUserAsync(string userId, string[] roles);
        Task<string[]> GetRolesToUsersAsync(string userIdOrName);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
