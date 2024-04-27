namespace DataAccess.Infrastructure.Repository;

using DataAccess.Entity;
using DataAccess.Infrastructure.Repository.Implementation;
using DataAccess.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
public static class InfrastructureRegistration
{
    public static IServiceCollection AddInsfrastructureService(this IServiceCollection services)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<User>, Repository<User>>();
        return services;
    }
}

