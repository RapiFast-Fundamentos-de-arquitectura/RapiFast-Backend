using System;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SmartStay.SharedKernel.Infrastructure.Mediator.Cortex.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddCortexMediatorServices(this WebApplicationBuilder builder, Type handlerAssemblyMarkerType)
    {
        builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
        builder.Services.AddCortexMediator(
            builder.Configuration,
            new[] { handlerAssemblyMarkerType }, 
            options =>
            {
                options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
            });
    }
}