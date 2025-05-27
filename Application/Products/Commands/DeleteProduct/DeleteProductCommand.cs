using Application.Abstrations.Messaging;
using Domain.Abstractions;

namespace Application.Products.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(int Id) : ICommand<bool>;
}
