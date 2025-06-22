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
            var productResult = Product.Create(command.Name, command.Price);

            if (productResult.IsFailure)
                return Result.Failure<int>(productResult.Error);

            var createResult = await _productRepository.
                AddAsync(productResult.Value, cancellationToken);

            if (createResult.IsFailure)
                return Result.Failure<int>(createResult.Error);

            return Result.Success(createResult.Value);
        }
    }
}
