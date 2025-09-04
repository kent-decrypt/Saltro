using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Saltro.Application.Behaviours;
using Saltro.Application.Commands.Products;

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
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DataSourceRequestBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(CreateProduct).Assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}
