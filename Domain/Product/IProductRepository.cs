namespace Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<int> Create(Product product);
        Task<bool> Delete(Product product);
        Task<Product> Update(Product product);
    }
}
