using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productId = await _productRepository.
                Create(Product.CreateOrder(request.Name, request.Price), cancellationToken);
            if(productId == 0)
                return Result.Failure<int>(Error.NullValue);

            return Result.Success(productId);
        }
    }
}
