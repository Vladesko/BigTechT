using Application.Abstrations.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Queries.GetAll
{
    internal class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<IEnumerable<Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var productAsAsync = await _productRepository.GetAllAsync(cancellationToken);
            return Result.Success(productAsAsync);  
        }
    }
}
