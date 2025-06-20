using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace Products.Tests.Persistance.Repository
{
    public class CreateTests : BaseTestRepository
    {
        private const string DEFAULT_NAME = "Default product name";
        private const decimal DEFAULT_PRICE = 2;
        [Fact]
        public async Task CreateProduct_Should_ResultSuccess_WhenDataIsValid()
        {
            //Arrange
            var product = Product.Create(DEFAULT_NAME, DEFAULT_PRICE);

            //Act
            var result = await _repository.AddAsync(product, It.IsAny<CancellationToken>());
            _context.SaveChanges();

            //Assert
            result.IsSuccess.ShouldBeTrue();
            Assert.NotNull(_context.Products.FirstOrDefault(p => p.Name == DEFAULT_NAME));
        }
    }
}
