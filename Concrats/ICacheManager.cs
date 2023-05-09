using RedisCache.Contrib.Enums;
using System;
using System.Threading.Tasks;

namespace RedisCache.Contrib.Concrats
{
    public interface ICacheManager
    {
        ValueTask<object> ExecuteCacheAsync(string key, Func<object> data, TimeExpiration time);

        ValueTask<string> Get(string key);
    }
}
