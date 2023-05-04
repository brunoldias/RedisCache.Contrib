using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache.Contrib.Enums
{
    public enum TimeExpiration
    {
        Minute = 60,
        Hour = 3600,
        Day = 86400
    }
}
