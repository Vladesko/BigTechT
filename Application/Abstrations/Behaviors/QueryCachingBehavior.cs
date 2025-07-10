using Application.Interfaces.CachingInterfaces;
using Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Abstrations.Behaviors
{
    internal class QueryCachingBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICachedQuery where TResponse : Result
    {
        private readonly ICacheService _cacheService;
        private readonly ILogger<QueryCachingBehavior<TRequest, TResponse>> _logger;
        public QueryCachingBehavior(ICacheService cacheService, ILogger<QueryCachingBehavior<TRequest, TResponse>> logger)
        {
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse? cachedResult = await _cacheService.GetAsync<TResponse>(request.Key, cancellationToken);
            string name = typeof(TRequest).Name;
            if(cachedResult is not null)
            {
                _logger.LogInformation($"Take cache from {name}");
                return cachedResult;
            }

            TResponse result = await next();

            if(result.IsSuccess)
                await _cacheService.SetAsync(request.Key, result, request.Expiration, cancellationToken);

            return result;
        }
    }
}
