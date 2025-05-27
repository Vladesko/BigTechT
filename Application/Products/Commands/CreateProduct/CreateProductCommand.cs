using Application.Abstrations.Messaging;
using Domain.Abstractions;

namespace Application.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand(string Name, decimal Price) : ICommand<int>;
}
