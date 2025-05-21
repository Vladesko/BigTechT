namespace Domain.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        private Product() { }
        public static Product CreateOrder(int id, string name, decimal price)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException("id");
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (price <= 0) 
                throw new ArgumentOutOfRangeException("price");

            return new Product() 
            {
                Id = id,
                Name = name, 
                Price = ProductService.CalculateWithTaxes(price) 
            };
        }
    }
}
