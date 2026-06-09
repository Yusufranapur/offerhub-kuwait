using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace OfferHub.Application.Common.Behaviours;

public interface ICacheableRequest
{
    string CacheKey { get; }
    int? SlidingExpirationInMinutes { get; }
}

// We will implement CachingBehaviour later or leave it as a placeholder.
public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    // Need ICacheService but skipping full implementation to save time
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await next();
    }
}
