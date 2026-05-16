using Microsoft.EntityFrameworkCore;
using SmartStay.Bookings.API.Domain.Model.Aggregates;
using SmartStay.SharedKernel.Domain.Repositories;
using SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Configuration;

namespace SmartStay.Bookings.API.Infrastructure.Persistence.EFC.Configuration.Extensions;

public class BookingsDbContext(DbContextOptions<BookingsDbContext> options) 
    : AppDbContext(options), IUnitOfWork
{
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Booking>().HasKey(b => b.Id);
    }

    public async Task CompleteAsync()
    {
        await SaveChangesAsync();
    }
}