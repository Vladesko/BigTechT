namespace Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<string> Create(Product product, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<Product> UpdateAllProduct(Product product, CancellationToken cancellationToken);
    }
}
