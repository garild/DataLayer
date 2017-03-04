using System;
using System.Collections.Concurrent;
using System.Web;
using System.Web.Caching;

namespace BLL
{
    public class CacheEndpoint : ICache
    {
        private static readonly ConcurrentDictionary<string, object> Locks = new ConcurrentDictionary<string, object>();
        private static Cache _cache;
        protected static Cache Cache { get; set; }
        public static CacheEndpoint CacheInstance() => new CacheEndpoint();
        public CacheEndpoint()
        {

        }
        private void Add<TResultType>(string key, TResultType value, TimeSpan ExpirationTime = default(TimeSpan), CacheItemPriority? cacheItemPriority = null)
        {
            Cache.Insert(key,
                        value,
                        null,
                        ExpirationTime == default(TimeSpan) ? DateTime.Now.Add(TimeSpan.FromHours(2)) : DateTime.Now.Add(ExpirationTime), Cache.NoSlidingExpiration,
                        cacheItemPriority == null ? CacheItemPriority.Normal : cacheItemPriority.Value,
                        null
                            );
        }
        public TResultType GetCache<TResultType>(string key)
        {
            return (TResultType)Cache.Get(key);
        }

        public void ClearCache(string key)
        {
            Cache.Remove(key);
        }

        public TResultType GetorSetCache<TResultType>(string key, Func<TResultType> getdata, TimeSpan ExpirationTime = default(TimeSpan), CacheItemPriority? cacheItemPriority = null)
        {
            var resultData = GetCache<TResultType>(key);
            if (resultData == null)
            {
                lock (Locks.GetOrAdd(key, new object()))
                {
                    resultData = getdata();
                    if (resultData == null)
                        return default(TResultType);
                    else
                        Add<TResultType>(key, resultData, ExpirationTime, cacheItemPriority);
                }
            }
            return (TResultType)resultData;
        }


    }
}
