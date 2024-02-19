using Application.Common.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

/// <summary>
/// EF core implementation of <see cref="IBaseDbService"/>.
/// </summary>
public class BaseDbService(ApplicationDbContext dbContext) : IBaseDbService
{
    private readonly ApplicationDbContext dbContext = dbContext;

    /// <inheritdoc/>
    public Task<int> CommitChangesAsync(CancellationToken cancellationToken = default)
        => this.dbContext.SaveChangesAsync(cancellationToken);

    /// <inheritdoc/>
    public async Task<string?> GetEmployeeIdByUserIdAsync(string userId)
    {
        var employee = await dbContext.Employees
                                     .SingleOrDefaultAsync(e => e.UserId == userId);
        return employee?.Id;
    }
}
