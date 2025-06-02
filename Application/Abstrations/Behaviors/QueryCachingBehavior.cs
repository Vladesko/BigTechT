using MediatR;

namespace Application.Abstrations.Behaviors
{
    internal class QueryCachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            return await next(cancellationToken);
        }
    }
}
