namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            ValidationErrors = errors;
        }
        public IEnumerable<ValidationError> ValidationErrors { get; }
    }
}
