using Application.Products.Commands.CreateProduct;
using Domain.Abstractions;
using Domain.Product;
using Moq;
using Shouldly;

namespace Products.Tests.Application.Commands
{
    public class CreateCommandTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        public CreateCommandTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenEverythingOkay()
        {
            //Arrange
            var command = new CreateProductCommand("Iphone 14 Pro", 120.00m);
            var handler = new CreateProductCommandHandler(_mockProductRepository.Object);

            //Act
            Result<int> result = await handler.Handle(command, default);

            //Assert
            result.IsSuccess.ShouldBeTrue();
        }
    }
}
