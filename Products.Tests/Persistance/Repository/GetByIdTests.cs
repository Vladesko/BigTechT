using Moq;
using Shouldly;

namespace Products.Tests.Persistance.Repository
{
    public class GetByIdTests : BaseTestRepository
    {
        [Fact]
        public async Task GetProductById_Should_ResultSuccess_WhenIdIsValidAndExistInDb()
        {
            //Arrange
            var product = _context.Products.First();

            //Act
            var result = await _repository.
                GetByIdAsync(product.Id, It.IsAny<CancellationToken>());

            //Assert
            result.IsSuccess.ShouldBeTrue();
            result.Value.Id.ShouldBe(product.Id);
        }
    }
}
