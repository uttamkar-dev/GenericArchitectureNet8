using DataAccess.Infrastructure.Repository;
using DataAccess.Service.Interfaces;
using DataAccess.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Service;
public static class FactoryServiceRegistration
{
    public static IServiceCollection AddFactoryService(this IServiceCollection services)
    {
        services.AddInsfrastructureService();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}

