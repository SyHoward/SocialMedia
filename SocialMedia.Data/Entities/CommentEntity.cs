using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SocialMedia.Data.Entities;

public class CommentEntity
{
    [Key]
    public int Id {get; set;}

    [Required, MinLength(1), MaxLength(8000)]
    public string Text {get; set;} = string.Empty;

    [Required]
    [ForeignKey(nameof(Id))]
    public int AuthorId {get; set;}

    [Required]
    public int PostId {get; set;}

    //Virtual Replies
    // public virtual List<Replies> Replies {get; set;} = new();
}