using Microsoft.AspNetCore.Identity;
using SocialMedia.Data;
using SocialMedia.Data.Entities;
using SocialMedia.Models.User;

namespace SocialMedia.Services.User;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public UserService(ApplicationDbContext context,
                        UserManager<UserEntity> userManager,
                        SignInManager<UserEntity> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        UserEntity entity = new()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        
        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

        return registerResult.Succeeded;
    }
}
