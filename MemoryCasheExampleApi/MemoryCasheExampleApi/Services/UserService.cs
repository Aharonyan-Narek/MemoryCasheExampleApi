using MemoryCasheExampleApi.Constants;
using MemoryCasheExampleApi.DTOs;
using System.Collections.ObjectModel;

namespace MemoryCasheExampleApi.Services;

public class UserService : IUserService
{
    private readonly IUserCasheManager _userCasheManager;

    public UserService(IUserCasheManager userCasheManager)
    {
        _userCasheManager = userCasheManager;
    }
    public ReadOnlyCollection<User> GetUsersCache()
    {
        var users = _userCasheManager.Get(CashingKeys.UsersList);
        return users;
    }
}