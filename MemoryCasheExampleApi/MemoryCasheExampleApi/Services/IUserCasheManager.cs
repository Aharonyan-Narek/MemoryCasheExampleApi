using MemoryCasheExampleApi.DTOs;
using System.Collections.ObjectModel;

namespace MemoryCasheExampleApi.Services
{
    public interface IUserCasheManager
    {
        bool TryGetValue<T>(string key, out T data);
        ReadOnlyCollection<User> Get(string key);
        void Set<T>(string key, T data);
        void Remove(string key);
    }
}
