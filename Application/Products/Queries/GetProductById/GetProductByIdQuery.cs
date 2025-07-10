using Application.Abstrations.Messaging;
using Application.Interfaces.CachingInterfaces;
using Domain.Product;

namespace Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Query for get all products
    /// </summary>
    /// <param name="Id">Id of the product to be returned</param>
    public sealed record GetProductByIdQuery(int Id) : ICachedQuery<Product>
    {
        public string Key => $"product-id-{Id}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
    }
}
