using Application.Abstrations.Messaging;
using Domain.Product;

namespace Application.Products.Queries.GetProductById
{
    public sealed record GetProductByIdQuery(int Id) : IQuery<Product>;
}
