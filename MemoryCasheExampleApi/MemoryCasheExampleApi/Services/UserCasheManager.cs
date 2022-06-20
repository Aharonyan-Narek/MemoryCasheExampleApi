using MemoryCasheExampleApi.Constants;
using MemoryCasheExampleApi.Data;
using MemoryCasheExampleApi.DTOs;
using MemoryCasheExampleApi.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.ObjectModel;

namespace MemoryCasheExampleApi.Services
{
    public sealed class UserCasheManager : IUserCasheManager
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        public UserCasheManager(IMemoryCache memoryCache,
            IOptions<UserCasheOptions> userCasheOptions)
        {
            _memoryCache = memoryCache;
            var casheSettings = userCasheOptions.Value;
            _cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(casheSettings.SlidingExpirationSeconds))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(casheSettings.AbsoluteExpirationSeconds))
            .SetPriority(CacheItemPriority.Normal)
            .SetSize(casheSettings.SizeLimitInMB);
        }
        public bool TryGetValue<T>(string key, out T data)
        {
            return _memoryCache.TryGetValue<T>(key, out data);
        }
        public ReadOnlyCollection<User> Get(string key)
        {
            if (_memoryCache.TryGetValue(key, out ReadOnlyCollection<User> cashedUsers))
                return cashedUsers;

            var users = UserDbSimulator.GetUsers();
            _memoryCache.Set(CashingKeys.UsersList, users, _cacheOptions);

            return users;
        }
        public void Set<T>(string key, T data)
        {
            _memoryCache.Set(key, data, _cacheOptions);
        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
