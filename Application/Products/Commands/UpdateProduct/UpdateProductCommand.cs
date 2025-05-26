using Application.Abstrations.Messaging;
using Domain.Product;
using System.Windows.Input;

namespace Application.Products.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(int Id, string Name, decimal Price) : ICommand<Product>;

}
