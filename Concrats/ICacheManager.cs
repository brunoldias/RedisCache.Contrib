using RedisCache.Contrib.Enums;

namespace RedisCache.Contrib.Concrats
{
    public interface ICacheManager
    {
        Task<object> ExecuteCacheAsync(string key, Func<object> data, TimeExpiration time);

        Task<string> Get(string key);
    }
}
