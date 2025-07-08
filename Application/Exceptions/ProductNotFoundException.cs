namespace Application.Exceptions
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
        public ProductNotFoundException(string message) : base(message) 
        {
            
        }
    }
}
