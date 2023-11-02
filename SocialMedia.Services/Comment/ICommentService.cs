namespace SocialMedia.Models.Comment;

public interface ICommentService
{
    Task<IEnumerable<CommentListItem>> GetAllNotesAsync();
}