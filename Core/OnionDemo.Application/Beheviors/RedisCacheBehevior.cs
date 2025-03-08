using MediatR;
using OnionDemo.Application.Interfaces.RedisCache;

namespace OnionDemo.Application.Beheviors;

public class RedisCacheBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IRedisCacheService _redisCacheService;

    public RedisCacheBehevior(IRedisCacheService redisCacheService)
    {
        _redisCacheService = redisCacheService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is ICacheableQuery query)
        {
            string cacheKey = query.CacheKey;
            double cacheTime = query.CacheTime;

            TResponse cachedData = await _redisCacheService.GetAsync<TResponse>(cacheKey);
            if (cachedData is not null)
                return cachedData;

            var response = await next();
            if(response is not null)
                await _redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));

            return response;
        }

        return await next();
    }
}