using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialMedia.Data;
using SocialMedia.Data.Entities;

namespace SocialMedia.Services.Comment;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _dbContext; 
    private readonly int _userId;

    public CommentService(UserManager<UserEntity> userManager,
                        SignInManager<UserEntity> signInManager,
                        ApplicationDbContext dbContext)
    {
        var currentUser = signInManager.Context.User;
        var userIdClaim = userManager.GetUserId(currentUser);
        var hasValidId = int.TryParse(userIdClaim, out _userId);

        if (hasValidId == false)
            throw new Exception("Attempted to build CommentService without Id claim.");

        _dbContext = dbContext;
    }
}