using RedisCache.Contrib.Enums;
using System;
using System.Threading.Tasks;

namespace RedisCache.Contrib.Concrats
{
    public interface ICacheManager
    {
        Task<object> ExecuteCacheAsync(string key, Func<object> data, TimeExpiration time);

        Task<string> Get(string key);
    }
}
