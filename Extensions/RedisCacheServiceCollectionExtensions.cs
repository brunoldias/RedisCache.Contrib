using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using RedisCache.Contrib.Concrats;
using System;

namespace RedisCache.Contrib.Extensions
{
    /// <summary>
    ///  Instace of redis to configuration build services
    /// </summary>
    public static class RedisCacheServiceCollectionExtensions
    {
        /// <summary>
        /// Add method a application to start configuration redis cache
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddRedisCache(this IServiceCollection services, Action<RedisCacheOptions> action)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            services.AddStackExchangeRedisCache(action);
            services.AddScoped<ICacheManager, CacheManager>();
        }

    }
}
