using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Product product)
        {
            await _context.AddAsync(product);
            return product.Id;
        }

        public async Task<bool> Delete(Product product)
        {
            _context.Remove(product);
            return true;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Set<Product>().
                Where(p => p.Id == id).
                FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            var updatedProduct = _context.Set<Product>().Update(product).Entity;
            return updatedProduct;
        }
    }
}
