using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Cache_Maktab97.Infrastructure.Cache.RedisCache;
public class RedisCacheServices : IRedisCacheServices
{
    #region Fields
    private readonly IDistributedCache _distributedCache;
    #endregion

    #region Ctor
    public RedisCacheServices(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }
    #endregion

    #region Implementations
    public void SetSliding<T>(string key, T value, int expirationTime)
    {
        var cacheOptions = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromSeconds(expirationTime)
        };
        _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOptions);
    }

    public void Set<T>(string key, T value, int expirationTime)
    {
        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expirationTime)
        };
        _distributedCache.SetString(key,JsonSerializer.Serialize(value),cacheOptions);
    }

    public T Get<T>(string key)
    {
        var value = _distributedCache.GetString(key);

        if (value != null)
        {
            return JsonSerializer.Deserialize<T>(value);
        }

        return default;
    }

    public bool HasCache(string key)
    {
        var value = _distributedCache.GetString(key);

        return value != null;
    }

    #endregion

}