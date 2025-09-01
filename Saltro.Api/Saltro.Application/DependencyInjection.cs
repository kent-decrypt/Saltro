using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saltro.Application.Behaviours;

namespace Saltro.Application;

/// <summary>
/// Contains the dependency injections for the Saltro.Application project
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers the application services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DataSourceRequestBehavior<,>));
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}
