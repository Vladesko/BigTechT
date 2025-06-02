using Application.Abstrations.Messaging;
using Domain.Product;

namespace Application.Products.Queries.GetAll
{
    public record GetAllProductQuery() : IQuery<IEnumerable<Product>>;
}
