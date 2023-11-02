using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models.Post;

public class PostCreate
{
        [Required]
        [MinLength(1, ErrorMessage =  "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long.")]
        public string Title {get; set;} = string.Empty;

        [Required]
        [MaxLength(2000, ErrorMessage = "{0} must be no more than {1} characters long.")]
        public string Text {get; set;} = string.Empty;
}
