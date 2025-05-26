namespace Application.Exceptions
{
    public class ProductNotFound : Exception
    {
        public ProductNotFound(string message, Exception innerException) : base(message, innerException)
        {
            
        }
        public ProductNotFound(string message) : base(message) 
        {
            
        }
    }
}
