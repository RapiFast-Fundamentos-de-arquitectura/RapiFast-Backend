using SmartStay.SharedKernel.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Base implementation of the repository pattern using Entity Framework Core.
/// </summary>
/// <typeparam name="TEntity">The type of the domain entity.</typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    protected BaseRepository(DbContext context)
    {
        Context = context;
    }

    /// <inheritdoc/>
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    /// <inheritdoc/>
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    /// <inheritdoc/>
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}
