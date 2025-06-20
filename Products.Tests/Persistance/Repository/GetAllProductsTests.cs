using Moq;
using Shouldly;

namespace Products.Tests.Persistance.Repository
{
    public class GetAllProductsTests : BaseTestRepository
    {
        [Fact]
        public async Task GetProduct_Should_ResultSuccess_WhenEverythingOkay()
        {
            //Arrange
            var ct = It.IsAny<CancellationToken>();
            //Act
            var result = await _repository.GetAllAsync(ct);

            //Assert
            result.IsSuccess.ShouldBeTrue();
            Assert.NotNull(result.Value);
        }
    }
}
