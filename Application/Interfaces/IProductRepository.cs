using Application.Products.Commands.UpdateProduct;

namespace Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<int> CreateAsync(Product product, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task UpdateAllProductAsync(UpdateProductCommand command, CancellationToken cancellationToken); 
    }
}
