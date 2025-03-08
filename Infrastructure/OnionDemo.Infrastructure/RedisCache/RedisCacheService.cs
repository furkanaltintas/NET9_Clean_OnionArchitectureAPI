using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnionDemo.Application.Interfaces.RedisCache;
using StackExchange.Redis;

namespace OnionDemo.Infrastructure.RedisCache;

public class RedisCacheService : IRedisCacheService
{
    private readonly ConnectionMultiplexer redisConnection;
    private readonly IDatabase database;
    private readonly RedisCacheSettings settings;

    public RedisCacheService(IOptions<RedisCacheSettings> options)
    {
        settings = options.Value;
        ConfigurationOptions configuration = ConfigurationOptions.Parse(settings.ConnectionString);
        redisConnection = ConnectionMultiplexer.Connect(configuration);
        database = redisConnection.GetDatabase();
    }


    public async Task<T> GetAsync<T>(string key)
    {
        RedisValue value = await database.StringGetAsync(key);

        if (value.HasValue)
            return JsonConvert.DeserializeObject<T>(value);
        return default;
    }

    public async Task<T> SetAsync<T>(string key, T value, DateTime? expirationTime = null)
    {
        TimeSpan timeUnitExpiration = expirationTime.Value - DateTime.Now;
        await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration);

        return value;
    }
}