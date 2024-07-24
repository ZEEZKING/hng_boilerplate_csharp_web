using System.ComponentModel.DataAnnotations;


namespace Hng.Application.Features.UserManagement.Dtos
{
    public class UserRegisterRequestDto
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AvatarUrl { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [RegularExpression("^\\+?[1-500][0-9]{7,14}$", ErrorMessage = "Invalid Phone Number")]
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    }
}