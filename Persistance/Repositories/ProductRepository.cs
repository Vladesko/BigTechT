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
            await _context.AddAsync(product);
            return product.Id;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ??
                    throw new ProductNotFoundException($"Product with Id: {id} was not found"); 
            _context.Products.Remove(entity);
            return true;               
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken) ??
                    throw new ProductNotFoundException($"Product with Id: {id} was not found");              
            return product;       
        }
    }
}
