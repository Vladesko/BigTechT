using Application.Exceptions;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    internal class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<int> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.AddAsync(product, cancellationToken);
            return product.Id;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            _context.Products.Remove(entity);
            return true;               
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken) ??
                    throw new ProductNotFoundException($"Product with Id: {id} was not found");              
            return product;       
        }
        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            var prodcuts = await _context.Products.
                AsNoTracking().
                ToArrayAsync(cancellationToken);
            return prodcuts;
        }
    }
}
