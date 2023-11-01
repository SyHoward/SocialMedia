using Azure.Identity;
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
        if (await CheckEmailAvailability(model.Email) == false)
        {
            Console.WriteLine("Invalid email, already in use.");
            return false;
        }

        UserEntity entity = new()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName
        };
        
        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

        return registerResult.Succeeded;
    }
    
    public async Task<UserDetail?> GetUserByIdAsync(int userId)
    {
        UserEntity? entity = await _context.Users.FindAsync(userId);
        if (entity is null)
            return null;

        UserDetail detail = new()
        {
            Id = entity.Id,
            Email = entity.Email,
            FirstName = entity.FirstName!,
            LastName = entity.LastName!,
            // UserName = entity.UserName!
        };

        return detail;
    }
    private async Task<bool> CheckEmailAvailability(string email)
    {
        UserEntity? existingUser = await _userManager.FindByEmailAsync(email);
        return existingUser is null;
    }

}
