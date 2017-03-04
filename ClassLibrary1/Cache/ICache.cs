using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace BLL
{
    interface ICache
    {
        TResultType GetorSetCache<TResultType>(string key, Func<TResultType> getdata, TimeSpan ExpirationTime = default(TimeSpan), CacheItemPriority? cacheItemPriority = null);
        TResultType GetCache<TResultType>(string key);
        void ClearCache(string key);
    }
}
