using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;
public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting Request {@RequestName}, {@DateTimeUtc}", typeof(TRequest).Name, DateTime.UtcNow);
        try
        {
            var result = await next();
            _logger.LogInformation("Completed Request {@RequestName}, {@DateTimeUtc}", typeof(TRequest).Name, DateTime.UtcNow);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled Exception for Request {Name} {@Request}", typeof(TRequest).Name, request);
            throw;
        }
    }
}
