using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    // Ahora recibe TContext de forma genérica
    public static void AddDatabaseConfigurationServices<TContext>(this WebApplicationBuilder builder) where TContext : DbContext
    {
        builder.Services.AddDbContext<TContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found or is empty.");
            }
            
            if (builder.Environment.IsDevelopment())
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
            else 
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
            }
        });
    }
}