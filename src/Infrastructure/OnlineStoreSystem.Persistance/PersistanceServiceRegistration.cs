using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStoreSystem.Application.Common.Interfaces.Authentication;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Domain.Common;
using OnlineStoreSystem.Persistance.Authentication;
using OnlineStoreSystem.Persistance.Contexts;
using OnlineStoreSystem.Persistance.Repositories;

namespace OnlineStoreSystem.Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString"));
        });
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
