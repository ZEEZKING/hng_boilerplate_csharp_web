
using Hng.Application.Features.UserManagement.Dtos;
using MediatR;

namespace Hng.Application.Features.UserManagement.Commands
{
    public class UserRegisterCommand :IRequest<AuthResponseDto>
    {
        public UserRegisterRequestDto RegisterRequest { get; set; }
        public UserRegisterCommand(UserRegisterRequestDto registerRequest)
        {
            RegisterRequest = registerRequest;
            
        }
    }
}