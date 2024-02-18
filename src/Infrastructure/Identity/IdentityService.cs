
namespace Infrastructure.Identity;

using Application.Common.Contracts;
using Application.Common.Exceptions;
using Application.Models.DTO;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

/// <summary>
/// Asp .NET identity implementation for IIdentityService.
/// </summary>
public class IdentityService(UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext dbContext)
    : IIdentityService
{
    private readonly UserManager<ApplicationUser> userManager = userManager;
    private readonly IMapper mapper = mapper;

    private readonly ApplicationDbContext dbContext = dbContext;

    /// <inheritdoc/>
    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await this.userManager.FindByEmailAsync(email);
        return this.mapper.Map<ApplicationUser?, UserDto>(user);
    }

    /// <inheritdoc/>
    public async Task<bool> ValidatePasswordAsync(string email, string password)
    {
        var user = await this.userManager.FindByEmailAsync(email)
            ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));

        return await this.userManager.CheckPasswordAsync(user, password);
    }

    /// <inheritdoc/>
    public async Task<IList<string>> GetRolesAsync(string email)
    {
        var user = await this.userManager.FindByEmailAsync(email)
            ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));
        return await this.userManager.GetRolesAsync(user);
    }

    /// <inheritdoc/>
    public async Task<UserDto> CreateUserAsync(UserDto model, string password)
    {
        var user = this.mapper.Map<UserDto, ApplicationUser>(model);
        var identityResult = await this.userManager.CreateAsync(user, password);
        if (!identityResult.Succeeded)
        {
            throw new AppException(ApplicationError.Internal(identityResult.Errors.First().Description));
        }

        return model;
    }

    /// <inheritdoc/>
    public async Task<bool> DeactivateUserAsync(string email)
    {
        var user = await this.userManager.FindByEmailAsync(email)
            ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));

        user.IsDeleted = true;
        IdentityResult res = await this.userManager.UpdateAsync(user);
        return res.Succeeded;
    }

    /// <inheritdoc/>
    public async Task<UserDto> UpdateUserAsync(string userId, UserDto model)
    {
        var user = await this.userManager.FindByIdAsync(userId)
            ?? throw new AppException(ApplicationError.NotFound("A User with given user id not found."));

        // perform update on updateable fields
        user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;

        var identityResult = await this.userManager.UpdateAsync(user);
        if (!identityResult.Succeeded)
        {
            throw new AppException(ApplicationError.Internal(identityResult.Errors.First().Description));
        }

        return this.mapper.Map<UserDto>(user);
    }

    #region OtherMethods
    // /// <inheritdoc/>
    // public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
    // {
    //     var user = await this.userManager.FindByEmailAsync(email)
    //         ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));

    //     var identityResult = await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
    //     return identityResult.Succeeded;
    // }

    // /// <inheritdoc/>
    // public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
    // {
    //     var user = await this.userManager.FindByEmailAsync(email)
    //         ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));
    //     var identityResult = await this.userManager.ResetPasswordAsync(user, token, newPassword);
    //     return identityResult.Succeeded;
    // }

    // /// <inheritdoc/>
    // public async Task<string> GetPasswordResetTokenAsync(string email)
    // {
    //     var user = await this.userManager.FindByEmailAsync(email)
    //         ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));

    //     return await this.userManager.GeneratePasswordResetTokenAsync(user);
    // }

    // /// <inheritdoc/>
    // public async Task ForgetPasswordAsync(string email)
    // {
    //     var user = await this.userManager.FindByEmailAsync(email)
    //         ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));

    //     if (await this.userManager.IsLockedOutAsync(user))
    //     {
    //         throw new AppException(ApplicationError.Forbidden($"User is locked"));
    //     }

    //     await this.userManager.UpdateSecurityStampAsync(user);
    //     var token = await this.userManager.GeneratePasswordResetTokenAsync(user);

    //     // await this.emailService.SendEmailAsync(
    //     //     email,
    //     //     "Reset Password",
    //     //     $"Click <a href=\"https://localhost:5001/auth/password/token/{token}\">here</a> to reset your password");
    // }

    // /// <inheritdoc/>
    // public async Task<bool> ConfirmResetPasswordAsync(string email, string token, string newPassword)
    // {
    //     var user = await this.userManager.FindByEmailAsync(email)
    //         ?? throw new AppException(ApplicationError.NotFound("A User with given email not found."));

    //     if (await this.userManager.IsLockedOutAsync(user))
    //     {
    //         throw new AppException(ApplicationError.Forbidden($"User is locked"));
    //     }

    //     var result = await this.userManager.ResetPasswordAsync(user, token, newPassword);
    //     return result.Succeeded;
    // }

    // / <inheritdoc/>
    // public async Task<bool> AddRefreshTokenAsync(string token, string userId, int expireDays = 7)
    // {
    //     var user = await this.userManager.FindByIdAsync(userId)
    //         ?? throw new AppException(ApplicationError.Forbidden("User is not authenticated"));

    //     RefreshToken refreshToken = new RefreshToken
    //     {
    //         Token = token,
    //         CreatedAt = DateTime.UtcNow,
    //         UserId = user.Id,
    //         ExpiresAt = DateTime.UtcNow.AddDays(expireDays),
    //     };
    //     this.dbContext.RefreshTokens.Add(refreshToken);
    //     return (await this.dbContext.SaveChangesAsync()) > 0;
    // }

    // /// <inheritdoc/>
    // public async Task<bool> ValidateRefreshTokenAsync(string refreshToken)
    // {
    //     var storedToken = await this.dbContext.RefreshTokens.SingleOrDefaultAsync(r => r.Token == refreshToken)
    //         ?? throw new AppException(ApplicationError.Forbidden("The given refresh token is not accessible."));

    //     return storedToken.ExpiresAt > DateTime.UtcNow;
    // }

    // /// <inheritdoc/>
    // public async Task<bool> RemoveRefreshTokenAsync(string refreshToken)
    // {
    //     var storedToken = await this.dbContext.RefreshTokens.SingleOrDefaultAsync(r => r.Token == refreshToken) ?? throw new Exception();
    //     this.dbContext.RefreshTokens.Remove(storedToken);
    //     return await this.dbContext.SaveChangesAsync() > 0;
    // }
    #endregion
}
