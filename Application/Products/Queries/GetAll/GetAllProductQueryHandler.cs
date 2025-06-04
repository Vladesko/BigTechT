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
        /// <summary>
        /// The handle for complete query
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Collection of products as result of Success</returns>
        public async Task<Result<IEnumerable<Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var productAsAsync = await _productRepository.GetAllAsync(cancellationToken);
            return Result.Success(productAsAsync);  
        }
    }
}
