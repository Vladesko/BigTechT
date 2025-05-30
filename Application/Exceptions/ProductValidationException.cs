namespace Application.Exceptions
{
    public class ProductValidationException : Exception
    {
        public ProductValidationException(IEnumerable<ValidationError> errors)
        {
            ValidationErrors = errors;
        }
        public IEnumerable<ValidationError> ValidationErrors { get; }
    }
}
