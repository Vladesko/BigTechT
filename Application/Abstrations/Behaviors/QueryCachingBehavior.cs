using Application.Interfaces.CachingInterfaces;
using MediatR;

namespace Application.Abstrations.Behaviors
{
    internal class QueryCachingBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICachedQuery
    {
        private readonly ICacheService _cacheService;
        public QueryCachingBehavior(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return await next();
        }
    }
}
