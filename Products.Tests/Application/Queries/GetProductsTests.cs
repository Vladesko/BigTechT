using Application.Interfaces;
using Application.Products.Queries.GetAll;
using Domain.Abstractions;
using Domain.Product;
using Moq;
using Shouldly;

namespace Products.Tests.Application.Queries
{
    public class GetProductsTests
    {
        private const string DEFAULT_NAME_1 = "Name1";
        private const string DEFAULT_NAME_2 = "Name2";

        private const decimal DEFAULT_PRICE_1 = 1;
        private const decimal DEFAULT_PRICE_2 = 2;

        private readonly Mock<IProductRepository> _mockProductRepository;
        public GetProductsTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_Should_ResultSuccess()
        {
            //Arrange
            IEnumerable<Product> products = new Product[] //Necessary to indicate that this is an array
                {
                    Product.Create(DEFAULT_NAME_1, DEFAULT_PRICE_1),
                    Product.Create(DEFAULT_NAME_2, DEFAULT_PRICE_2)
                };

            _mockProductRepository.
                Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).
                ReturnsAsync(Result.Success(products));

            var qeury = new GetAllProductQuery();
            var handler = new GetAllProductQueryHandler(_mockProductRepository.Object);

            //Act
            Result<IEnumerable<Product>> result = await handler.
                Handle(qeury, It.IsAny<CancellationToken>());

            //Assert
            result.IsSuccess.ShouldBeTrue();
            result.Value.ShouldBe(products);            
        }
    }
}
