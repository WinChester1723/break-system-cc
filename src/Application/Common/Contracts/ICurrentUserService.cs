namespace Application.Common.Contracts;

/// <summary>
/// Represents a user.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    string? Id { get; }
}