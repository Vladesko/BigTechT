using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //https://www.youtube.com/watch?v=AWXTIlwDRAM
        public Task<Result<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
