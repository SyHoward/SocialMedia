using SocialMedia.Models.Post;

namespace SocialMedia.Services.Post;

public interface IPostService
{
    Task<PostListItem?> CreatePostAsync(PostCreate request);
    Task<IEnumerable<PostListItem>> GetAllPostsAsync();
}
