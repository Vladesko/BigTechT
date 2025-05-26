using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {         
            var productId = await _repository.Create(Product.CreateOrder(request.Name, request.Price), cancellationToken);
            return productId;
        }
    }
}
