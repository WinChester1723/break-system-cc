namespace Application.Common.Exceptions;

/// <summary>
/// Defines all error types application may raise.
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// The error is to be used for representing any internal server errors, that client should not be involved with.
    /// </summary>
    INTERNAL = 0,

    /// <summary>
    /// The error is to be used when the item of interest does not exist in the application context.
    /// </summary>
    NOT_FOUND = 1,

    /// <summary>
    /// The error is to be used when the item of interest should not be accessed by the clients.
    /// </summary>
    FORBIDDEN = 2,

    /// <summary>
    /// The error is to be used when the item of interest queried by the client is not valid within the given context.
    /// </summary>
    BAD_REQUEST = 3,
}