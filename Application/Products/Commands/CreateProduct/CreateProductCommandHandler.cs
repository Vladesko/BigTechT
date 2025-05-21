using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(Product.CreateOrder(request.Id, request.Name, request.Price));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}
