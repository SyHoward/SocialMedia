using SocialMedia.Data;
using SocialMedia.Data.Entities;
using Microsoft.AspNetCore.Identity;
namespace SocialMedia.Services.Post;
public class PostService : IPostService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId;

    public PostService(UserManager<UserEntity> userManager,
                        SignInManager<UserEntity> signInManager,
                        ApplicationDbContext dbContext)
        {
            var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if (hasValidId == false)
                throw new Exception("Attempted to build PostService without Id claim.");

            _dbContext = dbContext;
        } 
}