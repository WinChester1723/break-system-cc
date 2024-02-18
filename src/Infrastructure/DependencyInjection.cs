namespace Infrastructure;

using System.Reflection;
using Application.Common.Contracts;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Static class responsible for configuring dependency injection in the infrastructure layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds web services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining additional calls.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        // var connectionString = configuration.GetConnectionString("DefaultConnection");
        // services.AddDbContext<ApplicationDbContext>(options =>
        //     {
        //         options.UseSqlServer(connectionString);
        //     });
        services.AddScoped<DbContextInitialiser>();


        services
            .AddIdentity<ApplicationUser, IdentityRole>(x =>
        {
            x.Password.RequireDigit = false;
            x.Password.RequireUppercase = false;
            x.Password.RequireNonAlphanumeric = false;
            x.Password.RequiredLength = 6;
            x.SignIn.RequireConfirmedEmail = true;
        })
        .AddUserManager<UserManager<ApplicationUser>>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<DbContextInitialiser>();

        services.AddScoped<IBaseDbService, BaseDbService>();

        services.AddTransient<IIdentityService, IdentityService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
