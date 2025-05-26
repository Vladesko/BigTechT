using Application.Abstrations.Messaging;
using Domain.Product;
using MediatR;
using System.Windows.Input;

namespace Application.Products.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(Product Product) : ICommand<Unit>;

}
