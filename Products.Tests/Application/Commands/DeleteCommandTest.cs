using Application.Interfaces;
using Application.Products.Commands.DeleteProduct;
using Domain.Abstractions;
using Domain.Product;
using Moq;
using Shouldly;

namespace Products.Tests.Application.Commands
{
    public class DeleteCommandTest
    {
        private const int ID = 1;
        private const string NAME = "Name";
        private const decimal PRICE = 2;

        private readonly Mock<IProductRepository> _mockProductRepository;

        public DeleteCommandTest()
        {
            _mockProductRepository = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenIdIsExist()
        {
            //Arrange
            var product = Product.Create(NAME, PRICE);

            _mockProductRepository.
                Setup(r => r.DeleteAsync(ID, It.IsAny<CancellationToken>())).
                ReturnsAsync(true);

            var command = new DeleteProductCommand(ID);
            var handler = new DeleteProductCommandHandler(_mockProductRepository.Object);

            //Act
            Result<bool> result = await handler.Handle(command, It.IsAny<CancellationToken>());

            //Assert
            result.IsSuccess.ShouldBeTrue();
        }
    }
}
