using Application.Abstrations.Messaging;
using Application.Interfaces;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return Result.Success(result.Value);
        }
    }
}
