using Microsoft.AspNetCore.Builder;

namespace SmartStay.SharedKernel.Infrastructure.Documentation.OpenApi.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring OpenAPI and CORS middleware in the application pipeline.
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    /// Configures OpenAPI/Swagger middleware for API documentation and testing interface.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <remarks>
    /// Enables Swagger UI at /swagger endpoint for interactive API documentation.
    /// </remarks>
    public static void UseOpenApiConfiguration(this WebApplication app)
    {
        // Eliminamos app.MapOpenApi() ya que Swashbuckle mapea sus propias rutas internamente
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    /// <summary>
    /// Applies the configured CORS policy to allow cross-origin requests.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    public static void UseCorsPolicy(this WebApplication app)
    {
        // Corregido para que coincida con el nombre de la política definida en el Builder ("AllowFrontend")
        app.UseCors("AllowFrontend");
    }
}