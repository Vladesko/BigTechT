using Application.Interfaces;
using Application.Products.Commands.UpdateProduct;
using Domain.Abstractions;
using Domain.Product;
using Moq;
using Shouldly;

namespace Products.Tests.Application.Commands
{
    public class UpdateCommandTests
    {
        private const int ID = 1;
        private const string DEFAULT_NAME = "Default name";
        private const decimal DEFAULT_PRICE = 2;

        private const string CHANGED_NAME = "Changed name";
        private const decimal CHANGED_PRICE = 1;

        private readonly Mock<IProductRepository> _mockProductRepository;

        public UpdateCommandTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenIdIsExistsAndDataIsValid()
        {
            //Arrange
            var product = Product.Create(DEFAULT_NAME, DEFAULT_PRICE);

             _mockProductRepository.
                Setup(r => r.GetByIdAsync(ID, It.IsAny<CancellationToken>())).
                ReturnsAsync(product);

            var command = new UpdateAllProductCommand(ID, CHANGED_NAME, CHANGED_PRICE);
            var handler = new UpdateAllProductCommandHandler(_mockProductRepository.Object);

            //Act
            Result result = await handler.Handle(command, It.IsAny<CancellationToken>());

            //Assert
            result.IsSuccess.ShouldBeTrue();

            product.Name.ShouldBe(CHANGED_NAME);
            product.Price.ShouldBe(CHANGED_PRICE);
        }
    }
}
