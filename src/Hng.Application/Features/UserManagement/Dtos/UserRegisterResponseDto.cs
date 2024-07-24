using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hng.Application.Features.UserManagement.Dtos
{
    public class UserRegisterResponseDto
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AvatarUrl { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    }
}