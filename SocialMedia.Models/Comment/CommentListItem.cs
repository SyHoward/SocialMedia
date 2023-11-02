namespace SocialMedia.Models.Comment;

public class CommentListItem
{
    public int Id {get; set;}
    public string Text {get; set;} = string.Empty;
    public int AuthorId {get; set;}
    public int PostId {get; set;}
}