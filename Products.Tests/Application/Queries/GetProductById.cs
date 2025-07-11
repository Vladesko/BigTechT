﻿using Application.Interfaces;
using Application.Interfaces.CachingInterfaces;
using Application.Products.Queries.GetProductById;
using Domain.Abstractions;
using Domain.Product;
using Moq;
using Shouldly;

namespace Products.Tests.Application.Queries
{
    public class GetProductById
    {
        private const int DEFAULT_ID_1 = 1;

        private const string DEFAULT_NAME_1 = "Name1";
        private const string DEFAULT_NAME_2 = "Name2";

        private const decimal DEFAULT_PRICE_1 = 1;
        private const decimal DEFAULT_PRICE_2 = 2;

        private readonly Mock<ICacheService> _mockCacheService;
        private readonly Mock<IProductRepository> _mockProductRepository;
        public GetProductById()
        {
            _mockCacheService = new Mock<ICacheService>();
            _mockProductRepository = new Mock<IProductRepository>();
        }
        [Fact]
        public async Task Handle_Should_ResultSuccess_IdIsExist()
        {
            //Ararnge
             var product = Product.Create(DEFAULT_NAME_1, DEFAULT_PRICE_2).Value;
            _mockCacheService.
                Setup(s => s.GetAsync<Product>($"{DEFAULT_ID_1}", It.IsAny<CancellationToken>())).
                ReturnsAsync((Product?)null);

            var query = new GetProductByIdQuery(DEFAULT_ID_1);
            var handler = new GetProductByIdQueryHandler(_mockProductRepository.Object,
                                                         _mockCacheService.Object);
            //Act
            Result<Product> result = await handler.Handle(query, It.IsAny<CancellationToken>());

            //Assert
            result.IsSuccess.ShouldBeTrue();
            result.Value.ShouldBe(product);
        }
    }
}
