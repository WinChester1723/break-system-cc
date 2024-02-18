using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;

/// <summary>
/// Extension methods for initializing the application's database.
/// </summary>
public static class InitialiserExtensions
{
     /// <summary>
    /// Initializes the application's database by seeding default roles and users.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <remarks>
    /// This method is an extension method for the <see cref="WebApplication"/> class and
    /// can be used in the application startup configuration to ensure the database is
    /// properly initialized during application startup.
    /// </remarks>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
{
    using var scope = app.Services.CreateScope();

    var initialiser = scope.ServiceProvider.GetRequiredService<DbContextInitialiser>();

    await initialiser.TryMigrateAsync();
    await initialiser.TrySeedAsync();
}
}
