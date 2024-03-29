namespace Application.Common.Contracts;

using Application.Models.DTO;

/// <summary>
/// Identity Service.
/// </summary>
public interface IIdentityService
{
    /// <summary>
    /// Creates new user in the system.
    /// </summary>
    /// <param name="model">User's details.</param>
    /// <param name="password">User's password.</param>
    /// <returns>Finded user model.</returns>
    Task<UserDto> CreateUserAsync(UserDto model, string password);

    /// <summary>
    /// Creates new user in the system.
    /// </summary>
    /// <param name="email">User's email.</param>
    /// <returns>A boolean flag indicating wether user deactivation succeeded or not.</returns>
    Task<bool> DeactivateUserAsync(string email);

    /// <summary>
    /// Updates user with given details.
    /// </summary>
    /// <param name="userId">User's identity id.</param>
    /// <param name="model">User's details.</param>
    /// <returns>Updated user model.</returns>
    Task<UserDto> UpdateUserAsync(string userId, UserDto model);

    /// <summary>
    /// Gets a user with given email.
    /// </summary>
    /// <param name="email">User's email.</param>
    /// <returns>Finded user model.</returns>
    Task<UserDto?> GetUserByEmailAsync(string email);

    /// <summary>
    /// Gets user's roles by email.
    /// </summary>
    /// <param name="email">Email of the user.</param>
    /// <returns>The roles of the user.</returns>
    Task<IList<string>> GetRolesAsync(string email);

    #region OtherMethods
        // /// <summary>
    // /// Changes  user's password to `newPassword`.
    // /// </summary>
    // /// <param name="email">Email of the user.</param>
    // /// <param name="oldPassword">User's old password.</param>
    // /// <param name="newPassword">Password to change user's old password to.</param>
    // /// <returns>Wether password reset is succesfull or not.</returns>
    // Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword);

    // /// <summary>
    // /// Resets  user's password with `token`.
    // /// </summary>
    // /// <param name="email">Email of the user.</param>
    // /// <param name="token">Token for reset user password.</param>
    // /// <param name="newPassword">Password to rest user's old password to .</param>
    // /// <returns>Wether password reset is succesfull or not.</returns>
    // Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

    // /// <summary>
    // /// Resets user's password to `newPassword`.
    // /// </summary>
    // /// <param name="email">Email of the user.</param>
    // /// <returns>Password reset token generated.</returns>
    // Task<string> GetPasswordResetTokenAsync(string email);

    // /// <summary>
    // /// Validates user's password.
    // /// </summary>
    // /// <param name="email">Email of the user.</param>
    // /// <param name="password">Password of the user.</param>
    // /// <returns>CheckPassword result.</returns>
    // Task<bool> ValidatePasswordAsync(string email, string password);

    // /// <summary>
    // /// Sends reset password email.
    // /// </summary>
    // /// <param name="email">The email of the user.</param>
    // /// <returns>The <see cref="Task"/> representing the result of the forget password operation.</returns>
    // Task ForgetPasswordAsync(string email);

    // /// <summary>
    // /// Reset user's password with `token`.
    // /// </summary>
    // /// <param name="email">The email of the user.</param>
    // /// <param name="token">The token was generated by the <see cref="ForgetPasswordAsync"/> method to reset user's password.</param>
    // /// <param name="newPassword">The new password of the user.</param>
    // /// <returns>The <see cref="bool"/> indicating success of the reset password operation.</returns>
    // Task<bool> ConfirmResetPasswordAsync(string email, string token, string newPassword);

    // /// <summary>
    // /// Add refresh token to the database.
    // /// </summary>
    // /// <param name="token">Refresh token.</param>
    // /// <param name="userId">The user identity associated with the refresh token.</param>
    // /// <param name="expireDays">Refresh token expire days.</param>
    // /// <returns>If refresh token added successfully, return true else return false.</returns>
    // Task<bool> AddRefreshTokenAsync(string token, string userId, int expireDays = 7);

    // /// <summary>
    // /// Validate refresh token.
    // /// </summary>
    // /// <param name="refreshToken">The user refresh token.</param>
    // /// <returns>The <see cref="Task"/> of boolean representing the result of the validate refresh token operation.</returns>
    // Task<bool> ValidateRefreshTokenAsync(string refreshToken);

    // /// <summary>
    // /// Logout user.
    // /// </summary>
    // /// <param name="refreshToken">The user refresh token.</param>
    // /// <returns>If refresh token removed successfully, return true else return false.</returns>
    // Task<bool> RemoveRefreshTokenAsync(string refreshToken);
    #endregion
}
