using System.Security.Claims;
using Application.Common.Contracts;

namespace WebApi.Services;

/// <summary>
/// Represents a current user implementation that implements the <see cref="ICurrentUserService"/> interface.
/// </summary>
/// <param name="httpContextAccessor">The <see cref="IHttpContextAccessor"/> used to access the current HTTP context.</param>
/// <param name="baseDbService">The service for working with employee data.</param>
public class CurrentUserService(IHttpContextAccessor httpContextAccessor, IBaseDbService baseDbService) : ICurrentUserService
{
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
    private readonly IBaseDbService baseDbService = baseDbService;

    /// <inheritdoc/>
    public string? Id => this.httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    /// <inheritdoc/>
    public async Task<string?> GetEmployeeIdAsync()
    {
        return this.Id != null
            ? await this.baseDbService.GetEmployeeIdByUserIdAsync(this.Id)
            : null;
    }
}
