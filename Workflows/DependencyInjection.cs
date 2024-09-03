using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;


namespace Workflows;

public static class DependencyInjection
{
    public static IServiceCollection AddWorkflows(this IServiceCollection services)
    {
        Env.Load();

        // Get the connection string from the environment variable
        string? connectionString = Environment.GetEnvironmentVariable("WORKFLOW_DATABASE_URL");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("The connection string was not found in the environment variables.");
        }

        services.AddWorkflow(x => x.UsePostgreSQL(connectionString, true, true));

        return services;
    }
}