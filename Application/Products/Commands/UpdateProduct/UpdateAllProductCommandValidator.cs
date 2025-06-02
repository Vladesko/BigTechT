using FluentValidation;

namespace Application.Products.Commands.UpdateProduct
{
    internal class UpdateAllProductCommandValidator : AbstractValidator<UpdateAllProductCommand>
    {
        #region Errors messages
        private const string NEGATIVE_NUMBER_ERROR = "The number cannot be less than or equal to 0";
        private const string EMPTY_NAME_ERROR = "Name can not be empry";
        private const string BIG_NAME_ERROR = "The name can't be that big";
        #endregion
        public UpdateAllProductCommandValidator()
        {
            IdValidate();
            NameValidate();
            PriceValidate();
        }
        /// <summary>
        /// Validation for Id
        /// </summary>
        private void IdValidate()
        {
            RuleFor(p => p.Id).
                NotEmpty().
                Must(NotNegative).
                WithMessage(NEGATIVE_NUMBER_ERROR);
        }
        /// <summary>
        /// Validation for Name
        /// </summary>
        private void NameValidate()
        {
            RuleFor(p => p.Name).
                NotNull().NotEmpty().
                WithMessage(EMPTY_NAME_ERROR).
                MaximumLength(256).
                WithMessage(BIG_NAME_ERROR);
        }
        private void PriceValidate()
        {
            RuleFor(p => p.Price).
                NotEmpty().
                NotNull().
                Must(NotNegative).
                WithMessage(NEGATIVE_NUMBER_ERROR);
        }
        /// <summary>
        /// Check Id to make sure it is not less than or equal to 0
        /// </summary>
        /// <param name="value">Id of updated product</param>
        /// <returns>If Id is less than or equal to 0 then return false</returns>
        private bool NotNegative(int value)
        {
            if(value > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Check Price to make sure it is not less than or equal to 0
        /// </summary>
        /// <param name="value">Price of updated product</param>
        /// <returns>If price is less than or equal to 0 then return false</returns>
        private bool NotNegative(decimal value)
        {
            if (value > 0)
                return true;
            return false;
        }
    }
}
