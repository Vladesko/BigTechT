using Application.Abstrations.Messaging;
using Application.Interfaces;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {         
            var resultProduct = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if(resultProduct.IsFailure)
                return Result.Failure<Product>(resultProduct.Error);

            return resultProduct;
        }
    }
}
