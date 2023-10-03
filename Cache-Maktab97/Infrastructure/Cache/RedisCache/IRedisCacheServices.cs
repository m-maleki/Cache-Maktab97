namespace Cache_Maktab97.Infrastructure.Cache.RedisCache;
public interface IRedisCacheServices
{
    void SetSliding<T>(string key, T value, int expirationTime);
    void Set<T>(string key, T value, int expirationTime);
    T Get<T>(string key);
    bool HasCache(string key);
}