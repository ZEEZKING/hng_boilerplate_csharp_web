using System.Net;
using Hng.Application.Features.UserManagement.Commands;
using Hng.Application.Features.UserManagement.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hng.Web.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserLoginRequestDto loginRequest)
        {
            var command = new CreateUserLoginCommand(loginRequest);
            var response = await _mediator.Send(command);

            if (response == null || response.Data == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid credentials",
                    error = "Invalid email or password.",
                    status_code = StatusCodes.Status401Unauthorized
                });
            }

            return Ok(response);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] UserRegisterRequestDto registerRequest)
        {
            var command= new UserRegisterCommand(registerRequest);
            var response= await _mediator.Send(command);

            if (response is null)
                return Unauthorized(new AuthResponseDto{
                    Message="User Already Exists",
                    Data=null,
                    access_token=null
                });
            return CreatedAtAction("Register",response);
        }
    }
}
