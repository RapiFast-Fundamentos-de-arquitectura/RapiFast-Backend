using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class WebApplicationExtensions
{
    public static void EnsureDatabaseCreated<TContext>(this WebApplication app) where TContext : DbContext
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var context = services.GetRequiredService<TContext>();
        
        try
        {
            logger.LogInformation("Verificando y creando la base de datos si no existe...");
            var canConnect = context.Database.CanConnect();
            
            if (!canConnect) logger.LogInformation("La base de datos no existe. Creándola...");
            
            context.Database.EnsureCreated();
            logger.LogInformation("Base de datos verificada/creada exitosamente.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear la base de datos: {Message}", ex.Message);
            throw;
        }
    }
}