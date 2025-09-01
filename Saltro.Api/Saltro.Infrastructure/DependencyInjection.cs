using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saltro.Domain.Repository;
using Saltro.Infrastructure.Persistence;
using Saltro.Infrastructure.Persistence.Repositories;

namespace Saltro.Infrastructure;

/// <summary>
/// Contains the dependency injections for the Saltro.Infrastructure project
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers the persistence of Saltro database context
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SaltroDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Persistence")));

        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserAssociateRepository, UserAssociateRepository>();
        services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        services.AddScoped<IUserGroupsMappingRepository, UserGroupsMappingRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();

        return services;
    }
}
