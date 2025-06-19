using Application.Abstrations.Messaging;
using Application.Interfaces;
using Domain.Abstractions;


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
            var result = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
            if (result.IsFailure) 
                return Result.Failure(Error.NullValue);

            result.Value.Name = command.Name;
            result.Value.Price = command.Price;

            return Result.Success();
        }
    }
}
