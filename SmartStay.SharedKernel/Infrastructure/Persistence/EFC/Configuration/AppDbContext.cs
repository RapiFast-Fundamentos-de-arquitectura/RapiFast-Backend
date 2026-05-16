using Microsoft.EntityFrameworkCore;

namespace SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Base database context for shared kernel operations.
/// Subclasses should extend this to provide specific DbContext implementations.
/// </summary>
public abstract class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    protected AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Configures the database context options.
    /// </summary>
    /// <param name="builder">The builder used to configure the context options.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    /// <summary>
    /// Configures the model schema and relationships for the database.
    /// </summary>
    /// <param name="builder">The builder used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

