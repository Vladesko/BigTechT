using Domain.Abstractions;

namespace Domain.Product
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; } = string.Empty;
        //public string UniqueArticle { get; set; } = string.Empty;
        public decimal Price { get; set; }
       // public string Description { get; set; } = string.Empty;
        // public string ProductStatus { get; set; } = string.Empty; //TODO: Make as enum and ValueObject
       // public DateTime? UpdateAt { get; set; }
       // public DateTime CreatedAt { get; } = DateTime.Now;
        private Product(string name, decimal price) 
        {
            Name = name;
            Price = price;
        }
        public Product()
        {

        }
        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="price">Price of product without procents</param>
        /// <returns>Instance of product</returns>
        public static Result<Product> Create(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
                return Result.Failure<Product>(Error.NullValue);
            if (price <= 0) 
                return Result.Failure<Product>(Error.PriceInvalid);

            return new Product(name, ProductService.CalculateWithTaxes(price));
        }
    }
}
