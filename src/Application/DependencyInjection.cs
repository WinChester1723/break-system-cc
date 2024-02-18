namespace Application;

using System.Reflection;
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
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddMediatR(cfg =>
        // {
        //     cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        // });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
