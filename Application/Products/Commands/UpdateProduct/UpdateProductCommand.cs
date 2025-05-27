using Application.Abstrations.Messaging;
using Domain.Product;
using MediatR;

namespace Application.Products.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(Product Product) : ICommand<Unit>;

}
