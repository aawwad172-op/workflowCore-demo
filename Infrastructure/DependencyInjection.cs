using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        Env.Load(".env");
        // Get the connection string from the environment variable
        string? connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("The connection string was not found in the environment variables.");
        }

        // Register DbContext with the connection string from the configuration
        services.AddDbContext<LeaveRequestDBContext>(options =>
            options.UseNpgsql(connectionString));

        // Register the generic repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}