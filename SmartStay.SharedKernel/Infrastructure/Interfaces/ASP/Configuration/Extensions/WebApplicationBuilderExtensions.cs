using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SmartStay.SharedKernel.Domain.Repositories;
using SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Repositories;

namespace SmartStay.SharedKernel.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
/// Provides extension methods for configuring shared services in the web application builder.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Adds shared context services to the dependency injection container.
    /// </summary>
    /// <param name="builder">The web application builder.</param>
    public static void AddSharedContextServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
