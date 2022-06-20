using MemoryCasheExampleApi.DTOs;
using System.Collections.ObjectModel;

namespace MemoryCasheExampleApi.Services;

public interface IUserService
{
    ReadOnlyCollection<User> GetUsersCache();
}