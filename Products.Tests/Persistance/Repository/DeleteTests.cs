using Moq;
using Shouldly;

namespace Products.Tests.Persistance.Repository
{
    public class DeleteTests : BaseTestRepository
    {
        [Fact]
        public async Task DeleteProduct_Should_ResultSuccess_WhenIdIsValidAndExistInDb()
        {
            //Arrange
            var id = _context.Products.First().Id;

            //Act
            var result = await _repository.DeleteAsync(id, It.IsAny<CancellationToken>());
            _context.SaveChanges();

            //Assert
            result.IsSuccess.ShouldBeTrue();
            result.Value.ShouldBeTrue();
        }
    }
}
