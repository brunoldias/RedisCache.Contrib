using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisCache.Contrib.Concrats;
using RedisCache.Contrib.Enums;
using RedisCache.Contrib.Extensions;

namespace RedisCache.Contrib
{
    /// <summary>
    /// Instace create to store cache on redis
    /// </summary>
    public class CacheManager : ICacheManager
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions _options;
        public CacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;

        }

        /// <summary>
        /// Set cache or return a value already cached on redis
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<object> ExecuteCacheAsync(string key, Func<object> data, TimeExpiration time)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key is null");

            var valueCached = await Get(key);

            if (valueCached != null) return valueCached;

            var result = data.Invoke();

            if (result != null)
            {
                var cacheValue = JsonConvert.SerializeObject(result);
                await SetCacheAsync(key, cacheValue, time);
                return cacheValue;
            }

            return result;
        }
        /// <summary>
        /// Return a value cached
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string> Get(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        /// <summary>
        /// This is option set cache and save cache value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private async Task SetCacheAsync(string key, string value, TimeExpiration time)
        {
            var enumValue = (int)Enum.Parse(typeof(TimeExpiration), time.ToString());
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(enumValue),
                SlidingExpiration = TimeSpan.FromSeconds(enumValue),
            };
            await _distributedCache.SetStringAsync(key, value, options);
        }
    }
}