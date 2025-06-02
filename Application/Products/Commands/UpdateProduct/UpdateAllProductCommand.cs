using Application.Abstrations.Messaging;


namespace Application.Products.Commands.UpdateProduct
{
    public sealed record UpdateAllProductCommand(int Id, string Name, decimal Price) : ICommand;

}
