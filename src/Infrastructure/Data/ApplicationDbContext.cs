
namespace Infrastructure.Data;

using System.Reflection;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Application Database Context.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
/// </remarks>
/// <param name="options">The DbContextOptions.</param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    /// <summary>
    /// Gets the set of departments in the database.
    /// </summary>
    public DbSet<BreakRequest> BreakRequests => this.Set<BreakRequest>();

    /// <summary>
    /// Gets the set of evaluation cycle windows in the database.
    /// </summary>
    public DbSet<BreakSchedule> BreakSchedules => this.Set<BreakSchedule>();

    /// <summary>
    /// Gets the set of employees in the database.
    /// </summary>
    public DbSet<Employee> Employees => this.Set<Employee>();

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
