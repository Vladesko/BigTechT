﻿namespace Application.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
        public ProductNotFoundException(string message) : base(message) 
        {
            
        }
    }
}
