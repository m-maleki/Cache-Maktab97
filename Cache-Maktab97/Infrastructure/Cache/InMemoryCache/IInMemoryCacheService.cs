namespace Cache_Maktab97.Infrastructure.Cache.InMemoryCache;
public interface IInMemoryCacheService
{
    void SetSliding<T>(string key, T value, int expirationTime);
    void Set<T>(string key, T value, int expirationTime);
    T Get<T>(string key);
}