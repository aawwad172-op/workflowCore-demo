using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LeaveRequestDBContext>
    {
        public LeaveRequestDBContext CreateDbContext(string[] args)
        {
            // Load environment variables from .env file
            DotNetEnv.Env.Load();

            // // Get the connection string from the environment variable
            // var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

            // if (string.IsNullOrEmpty(connectionString))
            // {
            //     throw new InvalidOperationException("The connection string was not found in the environment variables.");
            // }

            // Create DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<LeaveRequestDBContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=HRS;Username=postgres;Password=admin");

            return new LeaveRequestDBContext(optionsBuilder.Options);
        }
    }
}
