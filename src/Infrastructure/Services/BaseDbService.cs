using Application.Common.Contracts;
using Infrastructure.Data;

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
}
