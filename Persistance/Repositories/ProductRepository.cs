using Application.Exceptions;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    //Make result pattern
    internal class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<string> Create(Product product, CancellationToken cancellationToken)
        {
            await _context.AddAsync(product);
            return product.Name;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ??
                    throw new ProductNotFound($"Product with Id: {id} was not found"); 
                 _context.Products.Remove(entity);
                return true;               
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ??
                    throw new ProductNotFound($"Product with Id: {id} was not found");              
                return product;       
        }

        public async Task<Product> UpdateAllProduct(Product product, CancellationToken cancellationToken)
        {
            var updatedProduct = _context.Products.Update(product).Entity;
            return updatedProduct;
        }
    }
}
