using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var isRemoved = await _productRepository.DeleteAsync(request.Id, cancellationToken);
            if(!isRemoved)           
                return Result.Failure<bool>(Error.RemoveFailed);
            
            return Result.Success(isRemoved);
        }
    }
}
