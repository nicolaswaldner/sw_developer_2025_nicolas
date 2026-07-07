using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SD.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Application.Services
{
    public class ApplicationCacheService : IApplicationCacheService
    {

        private readonly IMemoryCache memoryCache;
        private readonly ILogger logger;

        public ApplicationCacheService(IMemoryCache memoryCache, 
                                       ILogger<ApplicationCacheService> logger)
        {
            this.memoryCache = memoryCache; 
            this.logger = logger;
        }

        public T RetrieveFromCache<T>(string key, Func<T> callback, TimeSpan? absoluteExpirationToNow = null)
        {
            return memoryCache.RetrieveFromCache(key,  callback, absoluteExpirationToNow ?? TimeSpan.FromHours(2));
        }

        public async Task<T> RetrieveFromCacheAsync<T>(string key, Func<Task<T>> callback, TimeSpan? absoluteExpirationToNow = null)
        {
            return await memoryCache.RetrieveFromCacheAsync(key, callback, absoluteExpirationToNow ?? TimeSpan.FromHours(2));
        }
                

        public void ClearCache()
        {
            var success = this.memoryCache.ClearCache();
            if (success)
            {
                this.logger.LogInformation("Applilcation cache cleared!");
            }
            else
            {
                this.logger.LogError("Could not cast cache object to MemoryCache. Cache NOT cleared.");
            }
        }

        public void RemoveFromCach(string key)
        {
            this.memoryCache.Remove(key);
        }

      
    }
}
