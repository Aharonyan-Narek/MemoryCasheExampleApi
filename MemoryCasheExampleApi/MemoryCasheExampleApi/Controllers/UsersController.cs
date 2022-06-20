using MemoryCasheExampleApi.DTOs;
using MemoryCasheExampleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace MemoryCasheExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<ReadOnlyCollection<User>> GetUsers()
    {
        var result = _userService.GetUsersCache();
        return Ok(result);
    }
}