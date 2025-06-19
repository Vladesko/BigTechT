using Application.Interfaces;
using Domain.Abstractions;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    internal class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        private readonly ApplicationDbContext _context = context;
        //TODO: Maybe need add try catch block for catching exceptions and return failure result

        /// <summary>
        /// Add new entity in Database
        /// </summary>
        /// <param name="product">New product</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<int>> AddAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.AddAsync(product, cancellationToken);
            return Result.Success(product.Id);
        }
        /// <summary>
        /// Delete entity from Database by Id
        /// </summary>
        /// <param name="id">The id that will be used for deletion</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            if (entity.IsFailure)
                return Result.Failure<bool>(Error.RemoveFailed);

            _context.Products.Remove(entity.Value);
            return Result.Success(true);               
        }
        /// <summary>
        /// Get the product by id
        /// </summary>
        /// <param name="id">ID of the desired product</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<Product>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.
                FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if(product == null)
                return Result.Failure<Product>(Error.NullValue);

            return Result.Success(product);       
        }
        /// <summary>
        /// Get list of products
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Array of products</returns>
        public async Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await _context.Products.
                AsNoTracking().
                ToArrayAsync(cancellationToken);
            return Result.Success<IEnumerable<Product>>(products);
        }
    }
}
