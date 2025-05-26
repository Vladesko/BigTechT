using Application.Abstrations.Messaging;

namespace Application.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand(string Name, decimal Price) : ICommand<int>;
}
