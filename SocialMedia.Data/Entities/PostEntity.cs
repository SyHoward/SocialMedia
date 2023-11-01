using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Data.Entities;

public class PostEntity
{
    [Key]
    public int Id {get; set;}
    [Required]
    [ForeignKey(nameof(Author))]
    public int AuthorId {get; set;}
    public UserEntity Author {get; set;} = null!;
    [Required, MinLength(1), MaxLength(100)]
    public string Title {get; set;} = string.Empty;
    [Required, MinLength(1), MaxLength(2000)]
    public string Text {get; set;} = string.Empty;
    //*virtual list of Comments
    //*virtual list of Likes
}