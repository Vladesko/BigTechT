using FluentValidation;

namespace Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        private const string ID_NULL_ERROR = "Id can not be null";
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id).
                NotEmpty().NotNull().
                WithMessage(ID_NULL_ERROR).
                Must(IsValideId);
        }
        private bool IsValideId(int id)
        {
            if (id <= 0)
                return false;
            return true;
        }
    }
}
