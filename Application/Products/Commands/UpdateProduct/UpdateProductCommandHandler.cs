using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;
using MediatR;

namespace Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Result<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
