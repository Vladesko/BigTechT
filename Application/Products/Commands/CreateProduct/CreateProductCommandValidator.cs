using FluentValidation;

namespace Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private const string MIN_LENGTH_ERROR = "Name must be bigger";
        private const string MAX_LENGTH_ERROR = "Name is so big";

        private const string PRICE_EMPTY_ERROR = "Price can not be empry";
        public CreateProductCommandValidator()
        {
            //Name
            RuleFor(p => p.Name).NotEmpty().
                MinimumLength(2).
                WithMessage(MIN_LENGTH_ERROR).
                MaximumLength(256).
                WithMessage(MAX_LENGTH_ERROR);

            //Price
            RuleFor(p => p.Price).
                NotEmpty().
                WithMessage(PRICE_EMPTY_ERROR);
        }
    }
}
