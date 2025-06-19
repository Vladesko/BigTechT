using Application.Interfaces;
using Application.Products.Commands.CreateProduct;
using Domain.Abstractions;
using Domain.Product;
using Moq;
using Shouldly;

namespace Products.Tests.Application.Commands
{
    public class CreateCommandTests
    {
        private const string DEFAULT_NAME = "ProductNameDefault";
        private const decimal DEFAULT_PRICE = 2;

        private readonly Mock<IProductRepository> _mockProductRepository;
        public CreateCommandTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenResultIsSuccessFromRepository()
        {
            //Arrange
            _mockProductRepository.
                Setup(r => r.CreateAsync(
                    It.IsAny<Product>(),
                    It.IsAny<CancellationToken>())).
                ReturnsAsync(Result.Success(1));

            var command = new CreateProductCommand(DEFAULT_NAME, DEFAULT_PRICE);
            var handler = new CreateProductCommandHandler(_mockProductRepository.Object);

            //Act
            Result<int> result = await handler.Handle(command, It.IsAny<CancellationToken>());

            //Assert
            result.IsSuccess.ShouldBeTrue();
        }
    }
}
