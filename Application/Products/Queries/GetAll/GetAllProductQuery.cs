using Application.Abstrations.Messaging;
using Domain.Product;

namespace Application.Products.Queries.GetAll
{
    public sealed record GetAllProductQuery() : IQuery<IEnumerable<Product>>;
}
