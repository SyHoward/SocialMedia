using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Services.Comment;

namespace SocialMedia.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService noteService)
    {
        _commentService = commentService;
    }

    //GET api/Comment
    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentService.GetAllCommentsAsync();
        return Ok(comments);
    }

}



