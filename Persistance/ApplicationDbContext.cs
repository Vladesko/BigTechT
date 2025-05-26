using Application.Exceptions;
using Domain.Abstractions;
using Domain.Product;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Persistance
{
    //Можно сделать класс internal
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                int result = await base.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("Concurrency exception occurred.", ex);
            }
        }
        public async Task CommitAsync()
        {
            await Database.CommitTransactionAsync();
        }
        public async Task RollbackAsync()
        {
            await Database.RollbackTransactionAsync();
        }
    }
}
