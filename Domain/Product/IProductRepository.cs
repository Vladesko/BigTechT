namespace Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<int> Create(Product product, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        //TODO: Change this method, return result and maybe change parametrs for methods
        Task UpdateAllProduct(Product product, CancellationToken cancellationToken); 
    }
}
