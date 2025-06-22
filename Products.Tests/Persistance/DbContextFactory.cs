using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Products.Tests.Persistance
{
    public static class DbContextFactory
    {
        public const string PRODUCT_NAME_1 = "Product 1";
        public const string PRODUCT_NAME_2 = "Product 2";
        public const string PRODUCT_NAME_3 = "Product 3";

        public const decimal PRODUCT_PRICE_1 = 2;
        public const decimal PRODUCT_PRICE_2 = 3;
        public const decimal PRODUCT_PRICE_3 = 4;


        public static ApplicationDbContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            context.Products.AddRange(Products);
            context.SaveChanges();

            return context;
        }
        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
        private static IEnumerable<Product> Products =>
            [
                Product.Create(PRODUCT_NAME_1, PRODUCT_PRICE_1).Value,
                Product.Create(PRODUCT_NAME_2, PRODUCT_PRICE_2).Value,
                Product.Create(PRODUCT_NAME_3, PRODUCT_PRICE_3).Value
            ];
    }
}
