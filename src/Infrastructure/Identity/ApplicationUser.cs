
namespace Infrastructure.Identity;

using Microsoft.AspNetCore.Identity;

/// <summary>
///  Example base class.
/// </summary>
public class ApplicationUser : IdentityUser
{
    // /// <summary>
    // /// Gets or sets refresh token.
    // /// </summary>
    // public string? RefreshToken { get; set; }

    // /// <summary>
    // /// Gets or sets refresh token expiry time.
    // /// </summary>
    // public DateTime RefreshTokenExpiryTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or sets user deleted state.
    /// </summary>
    public bool IsDeleted { get; set; }
}
