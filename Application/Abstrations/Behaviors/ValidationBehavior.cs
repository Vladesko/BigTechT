using Application.Abstrations.Messaging;
using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Abstrations.Behaviors
{
    internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IBaseCommand
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_validators.Any())
                return await next();
            
            var context = new ValidationContext<TRequest>(request);
            var validationErrors = _validators.
                Select(validator => validator.Validate(context)).
                Where(vr => vr.Errors.Any()).
                SelectMany(vf => vf.Errors).
                Select(vf => new ValidationError(vf.PropertyName, vf.ErrorMessage)).
                ToList();

            if (validationErrors.Any()) //rename Validation
                throw new Exceptions.ValidationException(validationErrors);

            return await next();
        }
    }
}
