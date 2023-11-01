using Microsoft.AspNetCore.Mvc;
using SocialMedia.Services.User;

namespace SocialMedia.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
}

