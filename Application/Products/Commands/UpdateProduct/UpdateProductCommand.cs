using Application.Abstrations.Messaging;
using Domain.Product;
using MediatR;

namespace Application.Products.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(int Id, string Name, decimal Price) : ICommand;

}
