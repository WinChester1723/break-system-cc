namespace Application.Common.Exceptions;

/// <summary>
/// Represents basic error object the app can raise.
/// </summary>
public class ApplicationError(ErrorType errorType, string? description = null)
{
    /// <summary>
    /// Gets underlying error type.
    /// </summary>
    public ErrorType ErrorType { get; } = errorType;

    /// <summary>
    /// Gets the description of ApplicationError.
    /// </summary>
    public string? Description { get; } = description;

    /// <summary>
    /// Shortcut method for creating ApplicationError with Internal error type.
    /// </summary>
    /// <param name="description">(Optional) Description of error.</param>
    /// <returns>A new <see cref="ApplicationError"/> with property ErrorType set to Internal.</returns>
    public static ApplicationError Internal(string? description = null)
        => new(ErrorType.INTERNAL, description);

    /// <summary>
    /// Shortcut method for creating ApplicationError with NotFound error type.
    /// </summary>
    /// <param name="description">(Optional) Description of error.</param>
    /// <returns>A new <see cref="ApplicationError"/> with property ErrorType set to NotFound.</returns>
    public static ApplicationError NotFound(string? description = null)
        => new(ErrorType.NOT_FOUND, description);

    /// <summary>
    /// Shortcut method for creating ApplicationError with FORBIDDEN error type.
    /// </summary>
    /// <param name="description">(Optional) Description of error.</param>
    /// <returns>A new <see cref="ApplicationError"/> with property ErrorType set to FORBIDDEN.</returns>
    public static ApplicationError Forbidden(string? description = null)
        => new(ErrorType.FORBIDDEN, description);

    /// <summary>
    /// Shortcut method for creating ApplicationError with BADREQUEST error type.
    /// </summary>
    /// <param name="description">(Optional) Description of error.</param>
    /// <returns>A new <see cref="ApplicationError"/> with property ErrorType set to BADREQUEST.</returns>
    public static ApplicationError BadRequest(string? description = null)
        => new(ErrorType.BAD_REQUEST, description);
}
