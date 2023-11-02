using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly SocialMediaContext db;

    public LikeController(SocialMediaContext context)
    {
        db = context;
    }
       
    // GET: Like
    [HttpGet]
    public async Task<IActionResult> Details(int? userId, int? postId)
    {
        if (userId == null || postId == null)
        {
            return BadRequest();
        }

        var like = await db.Likes.FindAsync(new object[] { userId.Value, postId.Value });

        if (like == null)
        {
            return NotFound();
        }

        return Ok(like);
    }  

    // POST: Like/Create
    [HttpPost("Create")]
    public async Task<IActionResult> Create(int userId, int postId)
    {
        var like = new Like { UserId = userId, PostId = postId };

        if (await db.Likes.AnyAsync(l => l.UserId == userId && l.PostId == postId))
        {
            return Conflict(new { message = "Like already exists." });
        }

        db.Likes.Add(like);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(Details), new { userId = like.UserId, postId = like.PostId }, like);
    }

    // POST: Like/Delete
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int userId, int postId)
    {
        var like = await db.Likes.FindAsync(new object[] { userId, postId });

        if (like == null)
        {
            return NotFound();
        }

        db.Likes.Remove(like);
        await db.SaveChangesAsync();

        return NoContent(); 
    }
} 