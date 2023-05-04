using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache.Contrib.Extensions
{
    public static class StringExtensions
    {
        public static T GetValue<T>(this string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
