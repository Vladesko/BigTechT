namespace Domain.Product
{
    public static class ProductService
    {
        public static decimal CalculateWithTaxes(decimal price) =>
            price * 1.13m;
    }
}
