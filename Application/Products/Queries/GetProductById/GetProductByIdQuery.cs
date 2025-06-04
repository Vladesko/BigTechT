using Application.Abstrations.Messaging;
using Domain.Product;

namespace Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Query for get all products
    /// </summary>
    /// <param name="Id">Id of the product to be returned</param>
    public sealed record GetProductByIdQuery(int Id) : IQuery<Product>;
}
