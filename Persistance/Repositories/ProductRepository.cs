using Application.Exceptions;
using Application.Products.Commands.UpdateProduct;
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
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ??
                    throw new ProductNotFoundException($"Product with Id: {id} was not found");              
                return product;       
        }
        public async Task UpdateAllProductAsync(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == command.Id) ??
                    throw new ProductNotFoundException($"Product with Id: {command.Id} was not found");

            product.Price = command.Price;
            product.Name = command.Name;
        }
    }
}
