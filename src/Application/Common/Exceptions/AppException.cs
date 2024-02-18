namespace Application.Common.Exceptions;

/// <summary>
/// Represents App specific exception object.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AppException"/> class.
/// </remarks>
/// <param name="error">Error representation for the given exception.</param>
/// <param name="baseException">Underlying base exception.</param>
public class AppException(ApplicationError error, Exception? baseException = null) : Exception(error.Description)
{
    /// <summary>
    /// Gets underlying base exception.
    /// </summary>
    public Exception? BaseException { get; } = baseException;

    /// <summary>
    /// Gets application error encountered during exception.
    /// </summary>
    public ApplicationError ApplicationError { get; } = error;
}