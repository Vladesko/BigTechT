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
        public static Product CreateOrder(string name, decimal price)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (price <= 0) 
                throw new DivideByZeroException("price");

            return new Product(name, price);
        }
    }
}
