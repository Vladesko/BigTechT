namespace Domain.Product
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        private Product(string name, decimal price) 
        {
            Name = name;
            Price = price;
        }
        public static Product Create(string name, decimal price)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (price <= 0) 
                throw new DivideByZeroException(nameof(price));

            return new Product(name, ProductService.CalculateWithTaxes(price));
        }
    }
}
