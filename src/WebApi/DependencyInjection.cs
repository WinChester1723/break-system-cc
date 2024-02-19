namespace WebApi;

using System.Reflection;
using Application.Common.Contracts;
using WebApi.Services;

/// <summary>
/// Static class responsible for configuring dependency injection in the WebApi layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds web services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining additional calls.</returns>
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();


        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

       
        return services;
    }
}
