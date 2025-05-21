namespace Domain.Product
{
    public class ProductService
    {
        public static decimal CalculateWithTaxes(decimal price) =>
            price * 1.13m;
    }
}
