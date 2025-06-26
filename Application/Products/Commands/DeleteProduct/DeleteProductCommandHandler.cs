using Application.Abstrations.Messaging;
using Application.Interfaces;
using Domain.Abstractions;

namespace Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<bool>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteAsync(command.Id, cancellationToken);
            if(result.IsFailure)           
                return Result.Failure<bool>(result.Error);
            
            return Result.Success(result.Value);
        }
    }
}
