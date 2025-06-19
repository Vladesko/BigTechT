using Application.Interfaces;
using Domain.Abstractions;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    internal class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Result<int>> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.AddAsync(product, cancellationToken);
            return Result.Success(product.Id);
        }

        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            if (entity.IsFailure)
                return Result.Failure<bool>(Error.RemoveFailed);

            _context.Products.Remove(entity.Value);
            return Result.Success(true);               
        }

        public async Task<Result<Product>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.
                FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if(product == null)
                return Result.Failure<Product>(Error.NullValue);

            return Result.Success(product);       
        }
        public async Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await _context.Products.
                AsNoTracking().
                ToArrayAsync(cancellationToken);
            return Result.Success<IEnumerable<Product>>(products);
        }
    }
}
