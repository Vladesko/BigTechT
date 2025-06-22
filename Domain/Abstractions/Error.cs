namespace Domain.Abstractions
{
    public record Error(string Code, string Name)
    {
        /// <summary>
        /// The error says there's no error indicteat ths are not
        /// </summary>
        public static readonly Error None = new(string.Empty, string.Empty);
        /// <summary>
        /// Value is empty or equal to null
        /// </summary>

        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
        /// <summary>
        /// The error means that some entity could not be deleted
        /// </summary>
        public static readonly Error RemoveFailed = new("Error.Remove.Failed", "This entity was not removed");
        /// <summary>
        /// The error means that some entity could not be created
        /// </summary>
        public static readonly Error CreateFailed = new("Error.Create.Failed", "This entity was not created");
        /// <summary>
        /// The error means that the value on property of price was not valid
        /// </summary>
        public static readonly Error PriceInvalid = new("Price.Is.Invalid", "This price is invalid");
    }
}
