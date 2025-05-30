using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;
using MediatR;

namespace Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           await _productRepository.UpdateAllProductAsync(request, cancellationToken);
            
            return Result.Success(request.Id);
        }
    }
}
