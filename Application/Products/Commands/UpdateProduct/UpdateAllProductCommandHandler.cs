using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.UpdateProduct
{
    internal class UpdateAllProductCommandHandler : ICommandHandler<UpdateAllProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public UpdateAllProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(UpdateAllProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
            if (product == null) 
                return Result.Failure(Error.NullValue);

            product.Name = command.Name;
            product.Price = command.Price;

            return Result.Success();
        }
    }
}
