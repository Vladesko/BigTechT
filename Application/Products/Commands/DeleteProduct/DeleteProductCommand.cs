using Application.Abstrations.Messaging;

namespace Application.Products.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(int Id) : ICommand<bool>;
}
