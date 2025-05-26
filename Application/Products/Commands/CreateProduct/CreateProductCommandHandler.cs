using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        //TODO: Change string to int
        public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {         
            await _repository.Create(Product.CreateOrder(request.Name, request.Price), cancellationToken);
            return request.Name;
        }
    }
}
