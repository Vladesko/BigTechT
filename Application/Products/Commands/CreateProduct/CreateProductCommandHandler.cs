using Application.Abstrations.Messaging;
using Application.Interfaces;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.CreateProduct
{
    internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<int>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _productRepository.
                AddAsync(Product.Create(command.Name, command.Price), cancellationToken);

            if (result.IsFailure)
                return result;

            return Result.Success(result.Value);
        }
    }
}
