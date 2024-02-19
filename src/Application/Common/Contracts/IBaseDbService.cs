namespace Application.Common.Contracts;

/// <summary>
/// Represents a service to perform base operations on the db.
/// Needs to be implemented by all db Services.
/// </summary>
public interface IBaseDbService
{

    /// <summary>
    /// Commits all changes made to the database till the call.
    /// </summary>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>Task representing the number of entities states written to database.</returns>
    Task<int> CommitChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the employee id associated with a given user id.
    /// </summary>
    /// <param name="userId">The user's identifier.</param>
    /// <returns>The employee id or null if not found.</returns>
    Task<string?> GetEmployeeIdByUserIdAsync(string userId);
}
