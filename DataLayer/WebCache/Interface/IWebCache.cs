﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace DataLayer
{
    interface IWebCache
    {
        TResultType GetorSetCache<TResultType>(string key, Func<TResultType> getdata, TimeSpan ExpirationTime = default(TimeSpan), CacheItemPriority? cacheItemPriority = null);
      
    }
}
