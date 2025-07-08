using Domain.Abstractions;
using Domain.Product;

namespace Application.Interfaces.CachingInterfaces
{
    public interface ICacheService
    {
        Task<Result<Product>> GetProductById(int id, CancellationToken cancellationToken = default);
    }
}
