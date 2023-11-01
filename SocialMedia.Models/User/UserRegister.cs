using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models.User;

public class UserRegister
{
    [Required, EmailAddress]
    public string Email {get; set;} = string.Empty;

    [Required, MinLength(4)]
    public string Password {get; set;} = string.Empty;

    [Compare(nameof(Password))]
    public string ConfirmPassword {get; set;} = string.Empty;

    [MaxLength(100)]
    public string? FirstName {get; set;}

    [MaxLength(100)]
    public string? LastName {get; set;}
}