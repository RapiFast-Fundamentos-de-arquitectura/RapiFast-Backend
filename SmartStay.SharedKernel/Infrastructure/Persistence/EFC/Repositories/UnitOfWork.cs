using Microsoft.EntityFrameworkCore;
using SmartStay.SharedKernel.Domain.Repositories;

namespace SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Implementation of the unit of work pattern using Entity Framework Core.
/// </summary>
public class UnitOfWork(DbContext context) : IUnitOfWork
{
    /// <inheritdoc/>
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}
