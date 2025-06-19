using Domain.Abstractions;
using Domain.Product;

namespace Application.Interfaces;

public interface IProductRepository
{
    Task<Result<Product>> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<int>> AddAsync(Product product, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken);
}
