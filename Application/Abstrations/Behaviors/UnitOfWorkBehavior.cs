using Application.Abstrations.Messaging;
using Domain.Abstractions;
using MediatR;

namespace Application.Abstrations.Behaviors
{
    internal sealed class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next(cancellationToken); 
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}
