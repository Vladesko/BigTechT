using Application.Abstrations.Messaging;
using Application.Interfaces.CachingInterfaces;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
    {
        private readonly ICacheService _cacheService;
        public GetProductByIdQueryHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var resultProduct = await _cacheService.GetProductById(request.Id, cancellationToken);

            if(resultProduct.IsFailure)
                return Result.Failure<Product>(resultProduct.Error);

            return Result.Success(resultProduct.Value);
        }
    }
}
