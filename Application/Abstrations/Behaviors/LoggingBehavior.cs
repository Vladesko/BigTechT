using Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Application.Abstrations.Behaviors
{
    internal sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IBaseRequest
        where TResponse : Result
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string name = request.GetType().Name;
            try
            {
                _logger.LogInformation($"Execuring request: \"{name}\"");
                var result = await next(cancellationToken);
                if (result.IsSuccess)
                {
                    _logger.LogInformation($"Request: \"{name}\" processed successfully");
                }
                else
                {
                    using (LogContext.PushProperty("Error", result.Error, true))
                        _logger.LogError($"Request: \"{name}\" processed with error");                   
                }
                return result;
            }
            catch (Exception)
            {
                _logger.LogError($"Request processing failed \"{name}\"");
                throw;
            }
        }
    }
}
