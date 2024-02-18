
namespace Application.Models.DTO;

/// <summary>
/// User Data Transfer Object.
/// </summary>
public class UserDto
{
    /// <summary>
    /// Gets user id.
    /// </summary>
    public string? Id { get; init; }

    /// <summary>
    /// Gets user email.
    /// </summary>
    public string? Email { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether user's email is confirmed.
    /// </summary>
    public bool EmailConfirmed { get; set; }

    /// <summary>
    /// Gets user's phone number.
    /// </summary>
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// Gets a value indicating whether user is verified.
    /// </summary>
    public bool IsVerified { get; init; }

    /// <summary>
    /// Gets a value indicating whether user is deactivated.
    /// </summary>
    public bool IsDeactivated { get; init; }
}